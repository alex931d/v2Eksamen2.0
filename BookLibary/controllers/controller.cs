using BookLibary.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BookLibary.controllers
{
  
   public class controller
    { 
        database data = new database();

         public bool addlend(lending newlending, int UserId)
         {
            try
            {
                data.addLending(newlending, UserId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

         } 
         public bool CheckIfUserCanLend(lending lending)
            {
                if (data.IsLendingPast30Days(lending))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }  
        public List<lending> GetLendingData(int count)
        {
         try
         {
            return data.GetLendings(count);
         }
         catch (Exception)
         {
             return null;
         }
        }
       
        public bool TryLogin(string login, string password)
        {
            Users loggedinUser = data.LoginUser(login, password);

            if (loggedinUser != null)
            {
                bool isAdmin = data.CheckAdmin(loggedinUser.UserId);
                Global.UserId = loggedinUser.UserId;
                Global.name = loggedinUser.Username;
                if (isAdmin)
                {
                    MainWindow productsApp = new MainWindow();
                    productsApp.Show();
                    return true;
                }
                else
                {
                    ElevMenu productsApp = new ElevMenu();
                    productsApp.Show();
                    return true;
                }
            }
            else
            {
              
                return false;
            }
        }

        public bool GetLendingData(DataGrid datafield,int userId)
        {
            try
            {
                datafield.ItemsSource = data.GetUserLendings(userId);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool GetData<T>(DataGrid dataField, Func<List<T>> getDataMethod)
         {
             try
            {
                List<T> data = getDataMethod.Invoke();
                dataField.ItemsSource = data;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
         }
    }
         
}
