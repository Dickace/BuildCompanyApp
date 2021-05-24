using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCompany
{
    class MaterialListViewModel : Bindable
    {
        public ObservableCollection<MaterialList> materialLists;
        public ObservableCollection<MaterialList> MaterialLists {
            get
            {
                return materialLists;
            }
            set
            {
                materialLists = value;
                OnPropertyChanged("MaterialLists");
            }
        }

        MaterialList selectedMaterialList;
        public MaterialList SelectedMaterialList
        {
            get
            {
                return selectedMaterialList;
            }
            set
            {
                selectedMaterialList = value;
                OnPropertyChanged("SelectedMaterialList");
            }
        }

        public void DataRefresh()
        {
            Db = new buildcompanyContext();
            Db.MaterialLists.Load();
            MaterialLists = Db.MaterialLists.Local.ToObservableCollection();
            OnPropertyChanged("MaterialLists");
        }
        private MyCommand addCommand;
        private MyCommand saveCommand;
        private MyCommand removeCommand;


        public MyCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new MyCommand(obj =>
                    {
                        MaterialList materialList = new MaterialList();
                        materialList.IdMaterialList = 0;
                        MaterialLists.Add(materialList);
                        Db.MaterialLists.Add(materialList);
                        Db.SaveChanges();
                        DataRefresh();
                        
                        var nmaterialLists = Db.MaterialLists.OrderBy(nmaterialList => nmaterialList.IdMaterialList);
                        SelectedMaterialList = nmaterialLists.Last();
                    }
                    ));
            }

        }



        public MyCommand SaveCommand
        {

            get
            {
                return saveCommand ?? (saveCommand = new MyCommand(obj =>
                {
                    MaterialList materialList = obj as MaterialList;
                    if (materialList != null)
                    {
                        var newmaterialList = Db.MaterialLists.Find(materialList.IdMaterialList);
                        if (materialList.IdMaterialList != 0)
                        {


                            materialList = newmaterialList;
                            Db.Entry(materialList).State = EntityState.Modified;
                            Db.SaveChanges();
                            DataRefresh();


                        }
                        else
                        {
                           
                            Db.MaterialLists.Add(materialList);

                            Db.SaveChanges();
                            DataRefresh();
                        }
                    }
                }));
            }
        }

        public MyCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new MyCommand(obj =>
                    {
                        MaterialList materialList = obj as MaterialList;
                        if (materialList != null)
                        {
                            Db.MaterialLists.Load();
                            var newmaterialList = Db.MaterialLists.Find(materialList.IdMaterialList);
                            if (newmaterialList != null)
                            {
                                Db.MaterialLists.Remove(materialList);
                                Db.SaveChanges();
                                DataRefresh();
                            }
                            else
                            {

                                MaterialLists.Remove(materialList);
                                DataRefresh();

                            }


                        }
                    }));
            }
        }

        public ObservableCollection<Order> Orders { get; set; }
        public IEnumerable<OrderViewModel> OrderViewModels { get; private set; }


        public class OrderViewModel : Bindable
        {
            public OrderViewModel(Order model)
            {
                Model = model;
                OrderNumber = model.OrderNumber;
            }

            public int? OrderNumber { get; set; }
            public Order Model { get; set; }
        }

        public ObservableCollection<Material> Materials { get; set; }
        public IEnumerable<MaterialViewModel> MaterialViewModels { get; private set; }


        public class MaterialViewModel : Bindable
        {
            public MaterialViewModel(Material model)
            {
                Model = model;
                MaterialName = model.MaterialName;
            }

            public string MaterialName { get; set; }
            public Material Model { get; set; }
        }

        buildcompanyContext Db;
        public MaterialListViewModel(){
           
            Db = new buildcompanyContext();
            try
            {
                Db.MaterialLists.Load();
                MaterialLists = Db.MaterialLists.Local.ToObservableCollection();

                Db.Orders.Load();
                Orders = Db.Orders.Local.ToObservableCollection();
                var orderViewModels = new List<OrderViewModel>();
                foreach (var el in Orders)
                {
                    orderViewModels.Add(new OrderViewModel(el));
                }
                OrderViewModels = orderViewModels;

                Db.Materials.Load();
                Materials = Db.Materials.Local.ToObservableCollection();
                var materialViewModels = new List<MaterialViewModel>();
                foreach (var el in Materials)
                {
                    materialViewModels.Add(new MaterialViewModel(el));
                }
                MaterialViewModels = materialViewModels;
            }
            catch
            {

            }
            //Group data (bad realization)
            /*try
              {
                  Db.MaterialLists.Load();

                  var MaterialList = from mater in (from s in Db.MaterialLists
                                                    join m in Db.Materials on s.IdMaterial equals m.IdMaterial
                                                    join z in Db.Orders on s.IdOrder equals z.IdOrder
                                                    select new
                                                    {
                                                        OrderNumber = z.OrderNumber,
                                                        MaterialEndDate = s.MaterialEndDate,
                                                        MaterialCounts = s.MaterialCounts,
                                                        MaterialName = m.MaterialName
                                                    }
      ).ToList()
                                     group mater by mater.OrderNumber;
                  foreach (var el in MaterialList)
                  {
                      MaterialLists.Add(el);


                  }
              }
              catch
              {

              }*/
        }
    }
}
