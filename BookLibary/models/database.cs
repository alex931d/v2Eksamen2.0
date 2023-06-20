using BookLibary.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BookLibary
{
    public class database
    {
        hashing hash = new hashing();
        private string connectionString = "Data Source=CV-BB-5995;Initial Catalog=bogDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private DataSet Execute(string query)
        {
            DataSet resultSet = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection
            (connectionString))))
            {
                adapter.Fill(resultSet);
            }

            return resultSet;
        }
        public database()
        {
            try
            {
                SqlConnection ad = new SqlConnection(connectionString);
                ad.Open();
                ad.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
  
        public Users LoginUser(string login, string password)
        {
            List<Users> loggedinUsers = new List<Users>();
            string loginQuery = $"SELECT * FROM Users WHERE Users_Person_id = '{login}'";
            DataSet resultSet = Execute(loginQuery);

            if (resultSet.Tables[0].Rows.Count > 0)
            {
                string storedHashedPassword = (string)resultSet.Tables[0].Rows[0]["Users_Password"];
                bool passwordMatch = hash.comparePassword(password, storedHashedPassword);

                if (passwordMatch)
                {
                    Users user = new Users(
                        (int)resultSet.Tables[0].Rows[0]["Users_ID"],
                        (string)resultSet.Tables[0].Rows[0]["Users_Person_id"],
                        storedHashedPassword
                    );

                    loggedinUsers.Add(user);
                    return user;
                }
            }

            return null;
        }

        public List<UserCount> GetUserCounts()
        {
            List<UserCount> userCounts = new List<UserCount>();

            string query = "SELECT Users_Person_id, COUNT(*) AS UserCount FROM Users GROUP BY Users_Person_id";

            DataSet resultSet = Execute(query);
            DataTable resultTable = resultSet.Tables[0];

            foreach (DataRow row in resultTable.Rows)
            {
                string username = row["Users_Person_id"].ToString();
                int count = Convert.ToInt32(row["UserCount"]);

                UserCount userCount = new UserCount(username, count);
                userCounts.Add(userCount);
            }

            return userCounts;
        }
        public List<BookCount> GetBookCounts()
        {
            List<BookCount> bookCounts = new List<BookCount>();

            string query = "SELECT Books_Title, COUNT(*) AS BookCount FROM Books GROUP BY Books_Title";

            DataSet resultSet = Execute(query);
            DataTable resultTable = resultSet.Tables[0];

            foreach (DataRow row in resultTable.Rows)
            {
                string bookTitle = row["Books_Title"].ToString();
                int count = Convert.ToInt32(row["BookCount"]);

                BookCount bookCount = new BookCount(bookTitle, count);
                bookCounts.Add(bookCount);
            }

            return bookCounts;
        }

        public bool IsLendingPast30Days(lending lending)
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan difference = currentDate - lending.Lendings_Date1;
            return difference.TotalDays > 30;
        }
        public List<lending> GetLendings(int count)
        {
            List<lending> allLendings = new List<lending>();
            string allLendingsQuery = $"SELECT L.*, U.Users_Person_id FROM Lendings AS L INNER JOIN Users AS U ON L.Lendings_User = U.Users_ID WHERE Lendings_Count = '{count}'";

            DataSet resultSet = Execute(allLendingsQuery);
            DataTable lendingTable = resultSet.Tables[0];
            foreach (DataRow lendingRow in lendingTable.Rows)
            {
                int lendingId = (int)lendingRow["Lendings_ID"];
                DateTime lendingDate = (DateTime)lendingRow["Lendings_Date"];
                string username = (string)lendingRow["Users_Person_id"];
                string bookTitle = (string)lendingRow["Lendings_Book"];
                int lendingCount = (int)lendingRow["Lendings_Count"];

                lending newLending = new lending(
                    lendingId,
                    lendingDate,
                    int.Parse(username),
                    bookTitle,
                    lendingCount
                );
                allLendings.Add(newLending);
            }
            return allLendings;
        }
        public bool CheckAdmin(int userId)
        {
            List<Users> users = getUsers();

            foreach (Users user in users)
            {
                if (user.UserId == userId && userId == 5)
                {
                    return true; 
                }
            }

            return false; 
        }

        public List<Users> getUsers()
        {
            List<Users> allusers = new List<Users>(0);
            string allUsersQuery =
             $"SELECT * FROM Users";

            DataSet resultSet = Execute(allUsersQuery);
            DataTable userTable = resultSet.Tables[0];
            foreach (DataRow userRow in userTable.Rows)
            {
                int users_id = (int)userRow["Users_ID"];
                string users_name = (string)userRow["Users_Person_id"];
                string users_password = (string)userRow["Users_Password"];

                Users newuser = new Users(
                    users_id,
                    users_name,
                    users_password
                    );
                allusers.Add(newuser);
            }
            return allusers;
        }

        public void deleteUser(Users user)
        {
            string checkLendingToUserQuery =
             $"SELECT * FROM LendingToUser WHERE LendingToUser_UserID = {user.UserId}";
            DataSet resultSet = Execute(checkLendingToUserQuery);
            DataTable lendingToUserTable = resultSet.Tables[0];

            if (lendingToUserTable.Rows.Count > 0)
            {
                string deleteClassificationQuery =
                $"DELETE FROM LendingToUser WHERE LendingToUser_UserID = '{user.UserId}'";
                Execute(deleteClassificationQuery);
                string deleteUserQuery =
                    $"DELETE FROM Users WHERE Users_ID = '{user.UserId}'";
                Execute(deleteUserQuery);
            }
            else
            {
                string deleteUserQuery =
                 $"DELETE FROM Users WHERE Users_ID = '{user.UserId}'";
                Execute(deleteUserQuery);
            }
        }



        public void AddUser(Users user)
        {
          
            string checkUserQuery = $"SELECT * FROM Users WHERE Users_Person_id = '{user.Username}'";
            DataSet resultSet = Execute(checkUserQuery);
            DataTable userTable = resultSet.Tables[0];

       
            if (userTable.Rows.Count > 0)
            {
                throw new Exception("User with the same username already exists.");
            }

       
            string hashedPassword = hash.hashPassword(user.Password);
            string addUserQuery =
                $"INSERT INTO Users (Users_Person_id, Users_Password) " +
                $"VALUES('{user.Username}','{hashedPassword}')";
            Execute(addUserQuery);
        }
        public List<Books> getBooks()
        {
            List<Books> allbooks = new List<Books>(0);
            string allUsersQuery =
             $"SELECT * FROM Books";

            DataSet resultSet = Execute(allUsersQuery);
            DataTable userTable = resultSet.Tables[0];
            foreach (DataRow userRow in userTable.Rows)
            {
                int books_id = (int)userRow["Books_ID"];
                string books_Author = (string)userRow["Books_Author"];
                string books_Title = (string)userRow["Books_Title"];
                string books_Publisher = (string)userRow["Books_Publisher"];
                DateTime books_Year = (DateTime)userRow["Books_Year"];
                int books_Count = (int)userRow["Books_Number"];
                string books_ISBN = (string)userRow["Books_ISBN"];

                Books newbook = new Books(
                    books_id,
                    books_Author,
                    books_Title,
                     books_Publisher,
                     books_Year,
                     books_Count,
                     books_ISBN
                    );
                allbooks.Add(newbook);
            }
            return allbooks;
        }
        public void deleteBook(Books book)
        {
            string selectLendingToUserQuery =
                $"SELECT * FROM LendingToUser WHERE LendingsBook_ID IN (SELECT Lendings_ID FROM Lendings WHERE Lendings_Book = '{book.BookTitle}')";
            DataSet resultSet = Execute(selectLendingToUserQuery);
            DataTable lendingToUserTable = resultSet.Tables[0];

            if (lendingToUserTable.Rows.Count > 0)
            {
                string deleteLendingToUserQuery =
                    $"DELETE FROM LendingToUser WHERE LendingsBook_ID IN (SELECT Lendings_ID FROM Lendings WHERE Lendings_Book = '{book.BookTitle}')";
                Execute(deleteLendingToUserQuery);
            }

            string selectLendingsQuery =
                $"SELECT * FROM Lendings WHERE Lendings_Book = '{book.BookTitle}'";
            resultSet = Execute(selectLendingsQuery);
            DataTable lendingsTable = resultSet.Tables[0];

            if (lendingsTable.Rows.Count > 0)
            {
                string deleteLendingsQuery =
                    $"DELETE FROM Lendings WHERE Lendings_Book = '{book.BookTitle}'";
                Execute(deleteLendingsQuery);
            }

            string deleteBookQuery =
                $"DELETE FROM Books WHERE Books_ID = {book.BookID}";
            Execute(deleteBookQuery);
        }
        public void updateBook(Books book, string author, string title, string publisher, DateTime year, int count, string ISBN)
        {
         
            string updateBookQuery =
                $"UPDATE Books " +
                $"SET Books_Author = '{author}', " +
                $"Books_Title = '{title}', " +
                $"Books_publisher = '{publisher}', " +
                $"Books_Year = '{year}', " +
                $"Books_number = {count}, " +
                $"Books_ISBN = '{ISBN}' " +
                $"WHERE Books_ID = {book.BookID}";
            Execute(updateBookQuery);

            string updateLendingsQuery =
                $"UPDATE Lendings " +
                $"SET Lendings_Book = '{title}' " +
                $"WHERE Lendings_Book = '{book.BookTitle}'";
            Execute(updateLendingsQuery);
        }
        public void addBooks(Books book)
        {
            string addUserQuery =
                $"INSERT INTO Books (Books_Author, Books_Title,Books_publisher,Books_Year,Books_number,Books_ISBN) " +
                $"VALUES('{book.BookAuthor}','{book.BookTitle}','{book.BookPublisher}','{book.BookYear}','{book.BooksCount}','{book.BooksISBN}')";
            Execute(addUserQuery);
        }
        public void updateUser(Users user, string name, string password)
        {
            string hashedPassword = hash.hashPassword(password);
            string updateProductQuery =
              $"UPDATE Users " +
              $"SET Users_Person_id = '{name}'," +
              $" Users_Password = '{hashedPassword}' " +
              $"WHERE Users_ID = {user.UserId}";
            Execute(updateProductQuery);
        }

        public void updateLendings(lending lending,DateTime lendingDate,string LendingUser,string lendingBook,int count)
        {
            string updateClassificationQuery =
                $"UPDATE Lendings " +
                $"SET Lendings_Date = '{lendingDate}'" +
                $"Lendings_User = '{LendingUser}'" +
                $"Lendings_Book = '{lendingBook}'" + 
                $"Lendings_Count = '{count}'" + 
                $"WHERE Lendings_ID = '{lending.Lendings_ID1}'";
            Execute(updateClassificationQuery);
        }

        public void addLending(lending lending,int userID)
        {
            if (CanUserLendBooks(userID))
            {
                string selectBookQuery =
                    $"SELECT Books_number FROM Books WHERE Books_Title = '{lending.Lendings_Book1}'";
                DataSet resultSet = Execute(selectBookQuery);
                DataTable bookTable = resultSet.Tables[0];

                if (bookTable.Rows.Count > 0)
                {
                    int bookCount = Convert.ToInt32(bookTable.Rows[0]["Books_number"]);
                    int lendingCount = lending.Lendings_Count1;

                    if (lendingCount <= bookCount)
                    {
                        string addLendingQuery =
                        $"INSERT INTO Lendings (Lendings_Date, Lendings_User, Lendings_Book, Lendings_Count) " +
                        $"VALUES ('{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', {userID}, '{lending.Lendings_Book1}', {lending.Lendings_Count1});" +
                        "SELECT SCOPE_IDENTITY() AS LastInsertedLendingId";
                        DataSet resultSeta = Execute(addLendingQuery);
                        DataTable lendingIdTable = resultSeta.Tables[0];
                        int lendingId = Convert.ToInt32(lendingIdTable.Rows[0]["LastInsertedLendingId"]);

                        string addLendingToUserQuery =
                            $"INSERT INTO LendingToUser (LendingsBook_ID, LendingToUser_UserID) VALUES ({lendingId}, {userID})";
                        Execute(addLendingToUserQuery);

                        string updateBookCountQuery =
                            $"UPDATE Books SET Books_number = Books_number - {lendingCount} WHERE Books_Title = '{lending.Lendings_Book1}'";
                        Execute(updateBookCountQuery);
                    }
                    else
                    {
                        throw new Exception("Insufficient book count. Unable to lend the requested quantity.");
                    }
                }
                else
                {
                    throw new Exception("Book not found. Unable to perform lending.");
                }
            }
        }
        public List<lending> GetUserLendings(int userId)
        {
            List<lending> userLendings = new List<lending>();

        
            string getUserLendingsQuery =
                $"SELECT Lendings_ID, Lendings_Date, Lendings_Book,Lendings_User, Lendings_Count " +
                $"FROM Lendings " +
                $"WHERE Lendings_User = {userId}";

         
            DataSet resultSet = Execute(getUserLendingsQuery);
            DataTable lendingTable = resultSet.Tables[0];
            foreach (DataRow lendingRow in lendingTable.Rows)
            {
                int lendingId = (int)lendingRow["Lendings_ID"];
                DateTime lendingDate = (DateTime)lendingRow["Lendings_Date"];
                string lendingBook = (string)lendingRow["Lendings_Book"];
                int Lendings_User = (int)lendingRow["Lendings_User"];
                int lendingCount = (int)lendingRow["Lendings_Count"];
                lending lending = new lending(lendingId, lendingDate, Lendings_User, lendingBook, lendingCount);
                userLendings.Add(lending);
            }

            return userLendings;
        }
        public void deleteLending(lending lending)
        {
           
            string getLendingCountQuery =
                $"SELECT Lendings_Count " +
                $"FROM Lendings " +
                $"WHERE Lendings_ID = {lending.Lendings_ID1}";

            DataSet resultSet = Execute(getLendingCountQuery);
            DataTable lendingCountTable = resultSet.Tables[0];
            int lendingCount = Convert.ToInt32(lendingCountTable.Rows[0]["Lendings_Count"]);

     
            string updateBookCountQuery =
                $"UPDATE Books " +
                $"SET Books_number = Books_number + {lendingCount} " +
                $"WHERE Books_Title = '{lending.Lendings_Book1}'";

            Execute(updateBookCountQuery);

      
            string deleteLendingToUserQuery =
                $"DELETE FROM LendingToUser WHERE LendingsBook_ID = {lending.Lendings_ID1}";
            Execute(deleteLendingToUserQuery);

            string deleteLendingQuery =
                $"DELETE FROM Lendings WHERE Lendings_ID = {lending.Lendings_ID1}";
            Execute(deleteLendingQuery);
        }
        public bool CanUserLendBooks(int userID)
        {
     
            string checkLendingQuery =
                $"SELECT TOP 1 Lendings_Date " +
                $"FROM LendingToUser " +
                $"INNER JOIN Lendings ON LendingToUser.LendingsBook_ID = Lendings.Lendings_ID " +
                $"WHERE LendingToUser.LendingToUser_UserID = {userID} " +
                $"ORDER BY Lendings_Date DESC";

     
            DataSet resultSet = Execute(checkLendingQuery);
            DataTable lendingTable = resultSet.Tables[0];

            if (lendingTable.Rows.Count > 0)
            {
     
                DateTime lendingDate = (DateTime)lendingTable.Rows[0]["Lendings_Date"];
                DateTime currentDate = DateTime.Now;
                TimeSpan timeSinceLending = currentDate - lendingDate;

                if (timeSinceLending.TotalDays > 30)
                {
                    return false;
                }
            }

            return true;
        }

        /*   public void reservatePitch(DateTime reservationStart, DateTime reservationEnd, Users reservationToUser, pitch reservationToPitch, DateTime reservationDay)
          {
              string formattedReservationDay = reservationDay.ToString("yyyy-MM-dd");
              string addReservationQuery = $"INSERT INTO Reservations (Reservations_start, Reservations_end,Reservation_To_User,Reservations_Pitch,Reservations_Day) " +
                                           $"VALUES ('{reservationStart.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                                           $"'{reservationEnd.ToString("yyyy-MM-dd HH:mm:ss")}','{reservationToUser.Users_id}','{reservationToPitch.Pitchid}','{formattedReservationDay}')";
              Execute(addReservationQuery);
          }
         public List<TimeSpan> GetAvailableTimeSlots(DateTime selectedDate)
          {
              List<TimeSpan> availableTimeSlots = new List<TimeSpan>();

              TimeSpan startTime1 = new TimeSpan(10, 0, 0);
              TimeSpan endTime1 = new TimeSpan(14, 0, 0);
              TimeSpan startTime2 = new TimeSpan(18, 0, 0);
              TimeSpan endTime2 = new TimeSpan(22, 0, 0);


              List<DateTime> existingReservations = GetExistingReservations(selectedDate);


              if (existingReservations.Count > 0)
              {

                  foreach (DateTime reservation in existingReservations)
                  {

                      TimeSpan reservationStartTime = reservation.TimeOfDay;
                      TimeSpan reservationEndTime = reservationStartTime.Add(new TimeSpan(1, 0, 0));


                      RemoveReservedTimeSlot(availableTimeSlots, reservationStartTime, reservationEndTime);
                  }
              }

              while (startTime1 < endTime1)
              {
                  availableTimeSlots.Add(startTime1);
                  startTime1 = startTime1.Add(new TimeSpan(1, 0, 0));
              }

              while (startTime2 < endTime2)
              {
                  availableTimeSlots.Add(startTime2);
                  startTime2 = startTime2.Add(new TimeSpan(1, 0, 0));
              }

              return availableTimeSlots;
          }

          public List<DateTime> GetExistingReservations(DateTime selectedDate)
          {
              List<DateTime> existingReservations = new List<DateTime>();


              string getReservationsQuery = $"SELECT Reservations_start FROM Reservations " +
                                            $"WHERE CONVERT(date, Reservations_start) = '{selectedDate.ToString("yyyy-MM-dd")}'";
              DataSet result = Execute(getReservationsQuery);


              foreach (DataRow row in result.Tables[0].Rows)
              {
                  DateTime reservationStart = Convert.ToDateTime(row["Reservations_start"]);
                  existingReservations.Add(reservationStart);
              }

              return existingReservations;
          }

          public void RemoveReservedTimeSlot(List<TimeSpan> availableTimeSlots, TimeSpan reservationStart, TimeSpan reservationEnd)
          {

              for (int i = availableTimeSlots.Count - 1; i >= 0; i--)
              {
                  TimeSpan timeSlot = availableTimeSlots[i];


                  if (timeSlot >= reservationStart && timeSlot < reservationEnd)
                  {
                      availableTimeSlots.RemoveAt(i);
                  }
              }
          } */
    }
}
