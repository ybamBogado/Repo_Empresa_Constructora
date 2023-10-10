using System;
using System.Collections;

namespace TrabajoGrupal
{
    class Grupo
    {
        public class GrupoObrero
        {
            private static int contadorCodigoObra = 0;
            private int codigoObra;
            private ArrayList integrantes;

            public int CodigoObra
            {
                get { return codigoObra; }
                set { codigoObra = value; }
            }

            public ArrayList Integrantes
            {
                get { return integrantes; }
                set { integrantes = value; }
            }

            public GrupoObrero()
            {
                codigoObra = GenerarCodigoObra();
                integrantes = new ArrayList();
            }
            
            private int GenerarCodigoObra()
            {
                contadorCodigoObra++;
                return contadorCodigoObra;
            }

            public void AgregarObrero(Obrero nuevoObrero)
            {
                integrantes.Add(nuevoObrero);
            }

            public void EliminarObrero(Obrero obrero)
            {
                integrantes.Remove(obrero);
            }

            public int CantidadObreros()
            {
                return integrantes.Count;
            }

            public void MostrarIntegrantes()
            {
                Console.WriteLine("Integrantes del grupo de obreros (Código de obra: " + codigoObra + "):");
                foreach (Obrero obrero in integrantes)
                {
                    Console.WriteLine(obrero.Nomyape);
                }
            }
        }
    }
}
