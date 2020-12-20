namespace Domain
{
    public class Settings
    {
        public static string ConnectionString()
        {
            // Aqui vai a String de Conexão com o Banco de Dados
            // No nosso caso estamos usando SQLite que vai ser gerado fora dos projetos, na pasta raiz
            return "DataSource=../DataBase.sqlite";         
        }
    }
}