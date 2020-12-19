namespace Domain
{
    public class Settings
    {
        public static string ConnectionString()
        {
            //Aqui vai a String de Conexão com o Banco de Dados
            return "DataSource=../DataBase.db";

            // Como estamos usando uma base de dados em Memoria, estamos apenas dando um   
            // nome (DataBase) a essa base.
        }
    }
}