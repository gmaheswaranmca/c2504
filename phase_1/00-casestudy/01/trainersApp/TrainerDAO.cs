using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingFundamentalsProject
{
    internal class TrainerDAO
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TrainersDb;Integrated Security=True;dfsfs";
        /*
            how do you create the connection object?
            how do you create the command object?
            how do you write the parameterizied sql statement or query?
            how will you pass the value to the query?
            how will you establish the connection to database?
            how will you run the query?
        */
        public void Create(Trainer trainer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Trainers (Name, Place, Skill) VALUES (@Name, @Place, @Skill)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", trainer.name);
                cmd.Parameters.AddWithValue("@Place", trainer.place);
                cmd.Parameters.AddWithValue("@Skill", trainer.skill);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Read a Trainer by ID
         /*
    how do you create the connection object?
    how do you create the command object?
    how do you write the parameterizied sql statement or query?
    how will you pass the value to the query?
    how will you establish the connection to database?
    how will you run the query?
    what is reader object?
    how will you read a row or row-by-row many rows using reader object?
         what is job of the reader.Read() function?
         how do you use the reader object after Read() function?
    */
        public Trainer Read(int id)
        {
            Trainer trainer = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Place, Skill FROM Trainers WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    trainer = new Trainer((int)reader["Id"], reader["Name"].ToString(), reader["Skill"].ToString(),
                         reader["Place"].ToString());
                }
            }
            return trainer;
        }

        // Update a Trainer
        public void Update(Trainer trainer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Trainers SET Name = @Name, Place = @Place, Skill = @Skill WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", trainer.id);
                cmd.Parameters.AddWithValue("@Name", trainer.name);
                cmd.Parameters.AddWithValue("@Place", trainer.place);
                cmd.Parameters.AddWithValue("@Skill", trainer.skill);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete a Trainer by ID
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Trainers WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // List all Trainers
        public List<Trainer> ListAll()
        {
            List<Trainer> trainers = new List<Trainer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Place, Skill FROM Trainers";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Trainer trainer = new Trainer((int)reader["Id"], reader["Name"].ToString(), reader["Skill"].ToString(),
                         reader["Place"].ToString());
                    trainers.Add(trainer);
                }
            }
            return trainers;
        }
    }
}
