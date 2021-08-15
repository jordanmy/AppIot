using System;
using System.Collections.Generic;

namespace AppIot.Metodos
{
    public class clsCalculo
    {
        public clsCalculo()
        {

        }

        public List<string> calculoSalario(List<string> lista, ref Exception ex)
        {
            List<string> result = new List<string>();
            try
            {
                #region calculo
                clsValores clsvalor = new clsValores();
                string[] horasGenerales = clsvalor.Horas.Split(';');

                foreach (var item in lista)
                {
                    #region Variables
                    var valor = 0;
                    string[] valores = item.Split('=');
                    string usuario = valores[0].Replace(" ", String.Empty);
                    string cadena = valores[1].Replace(" ", String.Empty);
                    valores = cadena.Split(',');
                    List<string> listhoras = new List<string>();
                    List<string> listdias = new List<string>();
                    obtenerlistaDiasHoras(valores, ref listhoras, ref listdias);
                    string horainicioV = "";
                    string horafinV = "";
                    string horainicio = "";
                    string horafin = "";
                    int horas = 0;
                    #endregion

                    #region iteracion 
                    
                    for (int i = 0; i < listhoras.Count; i++)
                    {
                        if (listdias[i].Equals("SA") || listdias[i].Equals("SU")) // Domingo y sabado
                        {
                            string[] precios = clsvalor.PreciosabadoDomingo.Split(';');
                            int val = 0;
                            string[] horacalculo = listhoras[i].Split('-');
                            horainicio = horacalculo[0];
                            horafin = horacalculo[1];
                            foreach (var y in horasGenerales)
                            {
                                //hacer todo el proceso para obtener las horas y sus precios
                                string[] hora = y.Split('-');
                                horainicioV = hora[0];
                                horafinV = hora[1];
                                //comparar la hora

                                if (compararFechas(DateTime.Parse(horainicio), DateTime.Parse(horainicioV), DateTime.Parse(horafinV)))
                                {
                                    //dentro del horario
                                    int horasT = 0;
                                    if (!horafinV.Equals("00:00")&& DateTime.Parse(horafinV) < DateTime.Parse(horafin))
                                    {
                                        horasT = goObtenerHorasTrabajo(horainicio, horafinV);
                                        horainicio = DateTime.Parse(horafinV).AddMinutes(1).TimeOfDay.ToString();
                                    }
                                    else
                                    {
                                        horasT = goObtenerHorasTrabajo(horainicio, horafin);
                                    }

                                    //cambiar hora inicio a la anterior
                                    //horainicio = 
                                    var precio = int.Parse(precios[val]) * horasT;
                                    valor += precio;
                                }
                                val++;
                            }

                        }
                        else // dia lunes viernes
                        {
                            string[] precios = clsvalor.PrecioLunesViernes.Split(';');
                            int val = 0;
                            string[] horacalculo = listhoras[i].Split('-');
                            horainicio = horacalculo[0];
                            //transformar horas a listas de horas
                            horafin = horacalculo[1];
                            foreach (var y in horasGenerales)
                            {
                                //hacer todo el proceso para obtener las horas y sus precios
                                string[] hora = y.Split('-');
                                horainicioV = hora[0];
                                horafinV = hora[1];
                                //comparar la hora

                                if(compararFechas(DateTime.Parse(horainicio), DateTime.Parse(horainicioV), DateTime.Parse(horafinV)))
                                {
                                    //dentro del horario
                                    int horasT = 0;
                                    if (DateTime.Parse(horafinV) < DateTime.Parse(horafin))
                                    {
                                        horasT = goObtenerHorasTrabajo(horainicio, horafinV);
                                        horainicio = DateTime.Parse(horafinV).AddMinutes(1).TimeOfDay.ToString();
                                    }
                                    else
                                    {
                                        horasT = goObtenerHorasTrabajo(horainicio, horafin);
                                    }
                                    
                                    //cambiar hora inicio a la anterior
                                    //horainicio = 
                                    var precio = int.Parse( precios[val]) * horasT;
                                    valor +=precio;
                                }
                                val++;
                            }
                        }
                    }
                    #endregion

                    #region iteracion nula
                    /*
                    for (int i = 0; i < listhoras.Count; i++)
                    {
                        if (listdias[i].Equals("SA") || listdias[i].Equals("SU")) // Domingo y sabado
                        {
                            string[] precios = clsvalor.PreciosabadoDomingo.Split(';');
                            int val = 0;
                            string[] horacalculo = listhoras[i].Split('-');
                            horainicio = horacalculo[0];
                            horafin = horacalculo[1];
                            foreach (var y in horasCadena)
                            {
                                //hacer todo el proceso para obtener las horas y sus precios
                                string[] hora = y.Split('-');
                                horainicioV = hora[0];
                                horafinV = hora[1];


                                //TimeSpan horasTrabajo = obtenerHorasTrabajo(horainicio, horafin);


                                //comparar la hora

                                if (compararHoras(horainicio, horainicioV, horafinV) && compararHoras(horafin, horainicioV, horafinV))
                                {
                                    //dentro del horario
                                    var horasT = goObtenerHorasTrabajo(horainicio, horafin);
                                    var precio = int.Parse(precios[val]) * horasT;
                                    valor += precio;
                                    break;
                                }
                                val++;


                            }

                        }
                        else // dia lunes viernes
                        {
                            string[] precios = clsvalor.PrecioLunesViernes.Split(';');
                            int val = 0;
                            string[] horacalculo = listhoras[i].Split('-');
                            horainicio = horacalculo[0];
                            //transformar horas a listas de horas
                            horafin = horacalculo[1];
                            foreach (var y in horasCadena)
                            {
                                //hacer todo el proceso para obtener las horas y sus precios
                                string[] hora = y.Split('-');
                                horainicioV = hora[0];
                                horafinV = hora[1];
                                

                                


                                //comparar la hora

                                if (compararHoras(horainicio, horainicioV, horafinV) && compararHoras(horafin, horainicioV, horafinV))
                                {
                                    //dentro del horario
                                    var horasT = goObtenerHorasTrabajo(horainicio, horafin);
                                    var precio = int.Parse( precios[val]) * horasT;
                                    valor +=precio;
                                    break;
                                }
                                val++;


                            }
                        }
                    }




                    */
                    #endregion


                    result.Add(usuario+";"+valor.ToString());

                }

                #endregion

                return result;
            }

            catch (Exception e)
            {
                ex = e;
                return null;
            }
            
        }
        public static bool compararFechas(DateTime time, DateTime startTime, DateTime endTime)
        {
            if (time.TimeOfDay == startTime.TimeOfDay) return true;
            if (time.TimeOfDay == endTime.TimeOfDay) return true;

            if (startTime.TimeOfDay <= endTime.TimeOfDay)
                return (time.TimeOfDay >= startTime.TimeOfDay && time.TimeOfDay <= endTime.TimeOfDay);
            else
                return !(time.TimeOfDay >= endTime.TimeOfDay && time.TimeOfDay <= startTime.TimeOfDay);
        }


        #region Metodos externos -  dias y horas
        public void obtenerlistaDiasHoras(string[] lista, ref List<string> listhoras, ref List<string> listdias)
        {
            foreach (var item in lista)
            {
                listdias.Add(item.Substring(0, 2));
                listhoras.Add(item.Substring(2));
            }
        }


        public int  goObtenerHorasTrabajo(String dInicial, String dFinal)
        {

            //revisar para obtener porcentaje en caso de que trabaje 40 minutos
            string horainicio = DateTime.Parse(dInicial).ToString("HH:mm");
            string horafin = DateTime.Parse(dFinal).ToString("HH:mm");
            var horas = 0;
            if (!horafin.Equals("00:00"))//case especial
            {
                horas= int.Parse(horafin.Split(':')[0]) - int.Parse(horainicio.Split(':')[0]); //revisar
                return horas;
            }
            horas = 24 - int.Parse( horainicio.Split(':')[0]);

            return horas;
        }

        #endregion

    }

}
