using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppIot.Funciones
{
    public class clsArchivo
    {
        public clsArchivo()
        {

        }
        #region leer archivo
        public List<string> obtenerarchivo(ref string nombrearchivo)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text|*.txt";
            dialog.FilterIndex = 1;
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileInfo fInfo = new System.IO.FileInfo(dialog.FileName);
                nombrearchivo = fInfo.Name;
                string direccionArchivo = fInfo.DirectoryName;
                return leerArchivo(direccionArchivo + "\\" + nombrearchivo);
                //return  direccionArchivo + "\\"+ nombrearchivo;
            }
            else
            {
                nombrearchivo = "";
                return null;
            }
        }

        
        public List<string> leerArchivo(string ruta)
        {
            List<string> lines = new List<string>();
            using (StreamReader ReaderObject = new StreamReader(ruta))
            {
                string Line;
                while ((Line = ReaderObject.ReadLine()) != null)
                {
                    lines.Add(Line);
                }
            }
            return lines;
        }
        #endregion
    }
}
