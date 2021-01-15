using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab9_Barcan_Florin_George_921.Models;
using MySql.Data.MySqlClient;

namespace Lab9_Barcan_Florin_George_921.DataAbstractionLayer
{
    public class DAL
    {
        public List<Recipe> GetRecipesFromAuthor(int author_id)
        {
            MySqlConnection connection;
            string connectionString;

            connectionString = "server=localhost;uid=root;pwd=;database=recipes";
            List<Recipe> recipeList = new List<Recipe>();

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from recipe where Recipe_Author_ID = " + author_id;
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Recipe recipe = new Recipe();
                    recipe.Recipe_ID = dataReader.GetInt32("Recipe_ID");
                    recipe.Recipe_Author_ID = dataReader.GetInt32("Recipe_Author_ID");
                    recipe.Recipe_Ingredients = dataReader.GetString("Recipe_Ingredients");
                    recipe.Recipe_Instructions = dataReader.GetString("Recipe_Instructions");
                    recipe.Recipe_Name = dataReader.GetString("Recipe_Name");
                    recipeList.Add(recipe);
                }
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            return recipeList;
        }

        public List<Recipe> GetRecipes()
        {
            MySqlConnection connection;
            string connectionString;

            connectionString = "server=localhost;uid=root;pwd=;database=recipes";
            List<Recipe> recipeList = new List<Recipe>();

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from recipe";
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Recipe recipe = new Recipe();
                    recipe.Recipe_ID = dataReader.GetInt32("Recipe_ID");
                    recipe.Recipe_Author_ID = dataReader.GetInt32("Recipe_Author_ID");
                    recipe.Recipe_Ingredients = dataReader.GetString("Recipe_Ingredients");
                    recipe.Recipe_Instructions = dataReader.GetString("Recipe_Instructions");
                    recipe.Recipe_Name = dataReader.GetString("Recipe_Name");
                    recipeList.Add(recipe);
                }
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }

            return recipeList;
        }

        public List<Author> GetAuthors()
        {
            MySqlConnection connection;
            string connectionString;

            connectionString = "server=localhost;uid=root;pwd=;database=recipes";
            List<Author> authorList = new List<Author>();

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from author";
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Author author = new Author();
                    author.Author_ID = dataReader.GetInt32("Author_ID");
                    author.Author_Name = dataReader.GetString("Author_Name");
                    authorList.Add(author);
                }
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }

            return authorList;
        }

        public User Login(string user_name, string pass_word)
        {
            MySqlConnection connection;
            string connectionString;

            connectionString = "server=localhost;uid=root;pwd=;database=recipes";
            User user = new User();

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from users where username = '" + user_name + "' and password = '" + pass_word + "';";
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    user.user_ID = dataReader.GetInt32("user_ID");
                    user.username = dataReader.GetString("username");
                    user.password = dataReader.GetString("password");
                }
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }

            return user;
        }

        public Recipe GetRecipe(int Recipe_ID)
        {
            MySqlConnection connection;
            string connectionString;

            connectionString = "server=localhost;uid=root;pwd=;database=recipes";
            Recipe recipe = new Recipe();

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from recipe where Recipe_ID = " + Recipe_ID;
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    recipe.Recipe_ID = dataReader.GetInt32("Recipe_ID");
                    recipe.Recipe_Author_ID = dataReader.GetInt32("Recipe_Author_ID");
                    recipe.Recipe_Ingredients = dataReader.GetString("Recipe_Ingredients");
                    recipe.Recipe_Instructions = dataReader.GetString("Recipe_Instructions");
                    recipe.Recipe_Name = dataReader.GetString("Recipe_Name");
                }
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }

            return recipe;
        }

        public Author GetAuthor(int Author_ID)
        {
            MySqlConnection connection;
            string connectionString;

            connectionString = "server=localhost;uid=root;pwd=;database=recipes";
            Author author = new Author();

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from author where Author_ID = " + Author_ID;
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    author.Author_ID = dataReader.GetInt32("Author_ID");
                    author.Author_Name = dataReader.GetString("Author_Name");
                }
                dataReader.Close();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }

            return author;
        }

        public void DeleteRecipe(int Recipe_ID)
        {
            MySqlConnection connection;
            string connectionString;

            connectionString = "server=localhost;uid=root;pwd=;database=recipes";

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "delete from recipe where Recipe_ID = " + Recipe_ID;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void DeleteAuthor(int Author_ID)
        {
            MySqlConnection connection;
            string connectionString;

            connectionString = "server=localhost;uid=root;pwd=;database=recipes";

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "delete from author where Author_ID = " + Author_ID;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void UpdateRecipe(int Recipe_ID, string Recipe_Name, string Recipe_Ingredients, string Recipe_Instructions)
        {
            MySqlConnection connection;
            string connectionString;

            connectionString = "server=localhost;uid=root;pwd=;database=recipes";

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update recipe set Recipe_Name = '" + Recipe_Name + "', Recipe_Ingredients = '" + Recipe_Ingredients + 
                    "', Recipe_Instructions = '" + Recipe_Instructions + "' where Recipe_ID = " + Recipe_ID;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void UpdateAuthor(int Author_ID, string Author_Name)
        {
            MySqlConnection connection;
            string connectionString;

            connectionString = "server=localhost;uid=root;pwd=;database=recipes";

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "update author set Author_Name = '" + Author_Name + "' where Author_ID = " + Author_ID;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void AddRecipe(int Recipe_Author_ID, string Recipe_Ingredients, string Recipe_Instructions, string Recipe_Name)
        {
            MySqlConnection connection;
            string connectionString;

            connectionString = "server=localhost;uid=root;pwd=;database=recipes";

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "insert into recipe (Recipe_Author_ID, Recipe_Ingredients, Recipe_Instructions, Recipe_Name) values(" + Recipe_Author_ID +
                    ", '" + Recipe_Ingredients + "', '" + Recipe_Instructions + "', '" + Recipe_Name + "')";
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }

        public void AddAuthor(string Author_Name)
        {
            MySqlConnection connection;
            string connectionString;

            connectionString = "server=localhost;uid=root;pwd=;database=recipes";

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "insert into author (Author_Name) values ('" +Author_Name + "')";
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}