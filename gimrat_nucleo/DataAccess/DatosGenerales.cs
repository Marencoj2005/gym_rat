namespace gimrat_nucleo.DataAccess;
// ¿para que es?
public class DatosGenerales
{
    public static string ruta_json = @"E:\Configuracion\secrets.json"; //como es esto en linux
    public static bool usa_azure = false;
    public static string clave = "EVBgi345936456ghhVBJGtgnifytsidi3456678jhgUTytutyiiyi";
    public static string usuario_datos = EncriptarConversor.Encriptar("Test.Trghhjsgdj");
}