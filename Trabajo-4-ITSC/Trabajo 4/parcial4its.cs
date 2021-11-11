using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_4;

namespace Parcial4
{
    class ListaPersonas
    {
        public System.Data.DataTable Data { get; set; } = new System.Data.DataTable();
        Persona perr { get; set; } = new Persona();
        public int UltimoId { get; set; } = 0;

        public ListaPersonas()
        {
            Data.TableName = "ListaPersonas";
            Data.Columns.Add("Id");
            Data.Columns.Add("Edad");
            Data.Columns.Add("Apellido");
            Data.Columns.Add("Nombre");
            

            LeerArchivo();
        }

        public void LeerArchivo()
        {
            if (System.IO.File.Exists("Lista.xml"))
            {
                //Datable.Clear();
                Data.ReadXml("Lista.xml");
                UltimoId = 0;
                for (int i = 0; i < Data.Rows.Count; i++)
                {
                    if (Convert.ToInt32(Data.Rows[i]["Id"]) > UltimoId)
                    {
                        UltimoId = Convert.ToInt32(Data.Rows[i]["Id"]);
                    }
                }
            }
        }
        public bool UpdatePersona(Persona usuario)
        {
            bool resp = usuario.Validar();

            if (resp)
            {
                if (usuario.Id == 0)
                {
                    UltimoId = UltimoId + 1;
                    usuario.Id = UltimoId;

                    Data.Rows.Add();
                    int NumeroRegistroNuevo = Data.Rows.Count - 1;

                    Data.Rows[NumeroRegistroNuevo]["Id"] = usuario.Id.ToString();
                    Data.Rows[NumeroRegistroNuevo]["Edad"] = usuario.edad.ToString();
                    Data.Rows[NumeroRegistroNuevo]["Apellido"] = usuario.apellido;
                    Data.Rows[NumeroRegistroNuevo]["Nombre"] = usuario.nombre;

                    Data.WriteXml("Lista.xml");
                }
                else
                {
                    for (int fila = 0; fila < Data.Rows.Count; fila++)
                    {
                        if (Convert.ToInt32(Data.Rows[fila]["Id"]) == usuario.Id)
                        {
                            Data.Rows[fila]["Edad"] = usuario.edad.ToString();
                            Data.Rows[fila]["Apellido"] = usuario.apellido;
                            Data.Rows[fila]["Nombre"] = usuario.nombre;
                            Data.WriteXml("Lista.xml");
                            break;
                        }
                    }
                }
            }
            return resp;
        }

        public bool BorrarLinea(Persona usuario)
        {
            bool resp = false;
            for (int fila = 0; fila < Data.Rows.Count; fila++)
            {
                if (Convert.ToInt32(Data.Rows[fila]["Id"]) == usuario.Id)
                {
                    Data.Rows[fila].Delete();
                    Data.WriteXml("Lista.xml");
                    resp = true;
                    break;
                }
            }

            return resp;
        }

        public bool Borrar(Persona usuario)
        {
            bool resp = false;

            Data.Rows.Clear();
            Data.WriteXml("Lista.xml");
            resp = true;
            return resp;
        }
    }



}

