using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result= new ML.Result();
            try
            {
                using(SqlConnection context= new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query= "AlumnoAdd";
                    using(SqlCommand cmd= new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                       
                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0]= new SqlParameter("Nombre",SqlDbType.VarChar);
                        collection[0].Value= alumno.Nombre;

                        collection[1]= new SqlParameter("ApellidoPaterno",SqlDbType.VarChar);
                        collection[1].Value= alumno.ApellidoPaterno;

                        collection[2]= new SqlParameter("ApellidoMaterno",SqlDbType.VarChar);
                        collection[2].Value= alumno.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[3].Value = alumno.FechaNacimiento;

                        collection[4] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[4].Value = alumno.CURP;

                        collection[5] = new SqlParameter("IdRol", SqlDbType.VarChar);
                        collection[5].Value = alumno.Roles.IdRol;

                        collection[6] = new SqlParameter("USERNAME", SqlDbType.VarChar);
                        collection[6].Value = alumno.UserName;

                        collection[7] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[7].Value = alumno.Password;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        cmd.Connection.Close();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El alumno no se pudo insertar correctamente.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[8];
                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = alumno.IdAlumno;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = alumno.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = alumno.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[3].Value = alumno.FechaNacimiento;

                        collection[4] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[4].Value = alumno.CURP;

                        collection[5] = new SqlParameter("IdRol", SqlDbType.VarChar);
                        collection[5].Value = alumno.IdRol;

                        collection[6] = new SqlParameter("USERNAME", SqlDbType.VarChar);
                        collection[6].Value = alumno.UserName;

                        collection[7] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[7].Value = alumno.Password;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        cmd.Connection.Close();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El Alumno no se pudo actualizar correctamente.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result Delete(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        cmd.Connection.Close();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El Alumno no se pudo eliminar correctamente.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoGetAll";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataTable tableAlumno = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tableAlumno);
                        if (tableAlumno.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableAlumno.Rows)
                            {
                                ML.Alumno alumno = new ML.Alumno();
                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();
                                alumno.FechaNacimiento = row[4].ToString();
                                alumno.CURP = row[5].ToString();
                                alumno.IdRol = int.Parse(row[6].ToString());
                                alumno.Roles = new ML.Roles();
                                alumno.Roles.IdRol = int.Parse(row[7].ToString());
                                alumno.Roles.Nombre = row[8].ToString();
                                alumno.UserName = row[9].ToString();
                                alumno.Password = row[10].ToString();
                                result.Objects.Add(alumno);
                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "NO SE ENCONTRARON REGISTROS";

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoGetById";


                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;
                        cmd.Parameters.AddRange(collection);

                        DataTable tableAlumno = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tableAlumno);
                        if (tableAlumno.Rows.Count > 0)
                        {
                                DataRow row = tableAlumno.Rows[0];  
                                ML.Alumno alumno = new ML.Alumno();
                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();
                                alumno.FechaNacimiento = row[4].ToString();
                                alumno.CURP = row[5].ToString();
                                alumno.IdRol = int.Parse(row[6].ToString());
                                alumno.Roles = new ML.Roles();                       
                                alumno.Roles.Nombre = row[7].ToString();
                                alumno.Roles.IdRol = int.Parse(row[8].ToString());
                                alumno.UserName = row[9].ToString();
                                alumno.Password = row[10].ToString();

                                 result.Object = alumno;
                                 result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "NO SE ENCONTRARON REGISTROS";

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


    }
}
