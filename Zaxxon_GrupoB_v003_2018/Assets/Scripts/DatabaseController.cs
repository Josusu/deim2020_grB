using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DatabaseController : MonoBehaviour
{

    private string conn;
    private int id, puntuacion;


    // Start is called before the first frame update
    void Awake()
    {
        //Ruta de la base de datos
        conn = "URI=file:" + Application.dataPath + "\\StreamingAssets\\Database.db";
    }

    public int[] leerPuntuacion()
    {
        int[] puntuaciones = new int[5];
        //Crear una variable de tipo IDbconnection
        IDbConnection dbConn;
        //Inicializas la variable como una SqliteConnection (hereda de IDbConnection)
        dbConn = new SqliteConnection(conn);
        //Abrir la conexion
        dbConn.Open();

        //Crea comando con la consulta select* (saca todos los datos de la tabla puntucaion)
        IDbCommand dbCommand = dbConn.CreateCommand();
        string sqlQuery = "Select * from puntuacion";
        dbCommand.CommandText = sqlQuery;

        //Leer de la base de datos
        IDataReader reader = dbCommand.ExecuteReader();

        int i = 0;
        //Bucle para leer la tabla
        while (reader.Read())
        {
            //Sacar datos del reader(columnas)
            id = reader.GetInt32(0);
            puntuacion = reader.GetInt32(1);
            puntuaciones[i] = puntuacion;
            i++;


        }

        //Cerrar toda la conexion
        reader.Close();
        reader = null;
        dbCommand.Dispose();
        dbCommand = null;
        dbConn.Close();
        dbConn = null;
        return puntuaciones;
    }


    void escribirPuntuacion(int id, int puntuacion)
    {
        //Crear una variable de tipo SqliteConnection y le pasas la ruta de la bbdd
        SqliteConnection dbConn = new SqliteConnection(conn);
        //Abrir la conexion
        dbConn.Open();

        //Crea comando con la consulta update 
        SqliteCommand dbCommand = new SqliteCommand(dbConn);
        dbCommand.CommandText = "update puntuacion set puntuacion = :score where ID=:id";
        dbCommand.Parameters.Add("score", DbType.Int32).Value = puntuacion;
        dbCommand.Parameters.Add("id", DbType.Int32).Value = id;
        dbCommand.ExecuteNonQuery();



        //Cerrar toda la conexion
        dbCommand.Dispose();
        dbCommand = null;
        dbConn.Close();
        dbConn = null;
    }

    public void colocarPuntuacion(int puntuacion)
    {
        int[] puntuaciones = leerPuntuacion();
        if(puntuaciones[4] < puntuacion)
        {
            puntuaciones[4] = puntuacion;
        }

        Array.Sort(puntuaciones);
        Array.Reverse(puntuaciones);

        for (int i = 0; i < puntuaciones.Length; i++)
        {
            escribirPuntuacion((i+1), puntuaciones[i]);
        }
    }

}
