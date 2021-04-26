using System;

namespace sistema__calculadora_de_prestamos
{
    class Program
    {
        static void Main(string[] args)
        {
            operacion o = new operacion();
            prestamos p = new prestamos();
            fecha f = new fecha();
            bool x = true;

            while (x)
            {
                int b;
                Console.Write("monto de prestamo en RD$= ");
                o.prestamo = float.Parse(Console.ReadLine());
                Console.Write("tasa de porsentaje anual= ");
                o.tasaanual = float.Parse(Console.ReadLine());
                Console.Write("plazo(el plazo debe ser en meses)= ");
                p.plazo = float.Parse(Console.ReadLine());

                Console.Clear();
                //b = t / 100;
                o.tasamensual = o.tasaanual / 12;

                //operacion1ra
                p.operacion1 = (1 + o.tasamensual / 100);
                p.elevacion = Math.Pow(p.operacion1, p.plazo);
                p.resultado1 = p.elevacion * o.prestamo * o.tasamensual / 100;

                //operacion2da
                p.operacion2 = 1 + o.tasamensual / 100;
                p.resultado2 = Math.Pow(p.operacion2, p.plazo) - 1;
                p.multiplicacio = Math.Round(p.resultado2 * 1000.0) / 1000.0;

                //cuota
                p.sacarcuota = p.resultado1 / p.resultado2;
                o.cuota = Math.Round(p.sacarcuota * 100.0) / 100.0;
                //interes
                p.sacandointeres = o.prestamo * o.tasamensual / 100;
                p.interes = Math.Round(p.sacandointeres * 100.0) / 100.0;

                //capital
                o.sacandocapital = p.sacarcuota - p.interes;
                p.capital = p.multiplicacio = Math.Round(o.sacandocapital * 100.0) / 100.0;

                //balance
                p.sacandobalance = o.prestamo - p.capital;
                p.balance = Math.Round(p.sacandobalance * 100.0) / 100.0;

                //fecha
                DateTime fecha = DateTime.Now;
                int pago = 0;

                //FechaBucle
                f.Dia = fecha.Day;
                f.Mes = fecha.Month + 1;
                f.Años = fecha.Year;
                f.Mes = fecha.Month;
                //CondicionPago     
                if (f.Dia > 28)
                {

                    f.Dia = 1;
                    f.Mes++;

                }
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("monto del prestamo en RD$=       " + o.prestamo);
                Console.WriteLine("tasa de porsentaje anual=        " + o.tasaanual);
                Console.WriteLine("plazo=                           " + p.plazo);
                Console.WriteLine("valor cuota=                     " + o.cuota);
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("fecha de " + "|||" + " cuota" + " |||" + "capital" + "|||" + "interes" + "|||" + "balance");
                Console.WriteLine("pago  " + "   |||");

                Console.WriteLine(f.Dia + "/" + ++f.Mes + "/" + f.Años + "|||" + o.cuota + "|||" + p.capital + "|||" + p.interes + "|||" + p.balance);
                Console.WriteLine("|");
                while (pago < p.plazo - 1)
                {
                    //2dointeres
                    double interes2, interes01;
                    interes01 = p.sacandobalance * o.tasamensual / 100;
                    interes2 = Math.Round(interes01 * 100.0) / 100.0;

                    //2docapital 2
                    double capital2, capital01;
                    capital01 = p.sacarcuota - interes2;
                    capital2 = Math.Round(capital01 * 100.0) / 100.0;

                    //2dobalance
                    double balance2, balance01;
                    balance01 = p.sacandobalance - capital2;
                    balance2 = Math.Round(balance01 * 100.0) / 100.0;
                    p.sacandobalance = balance2;

                    if (f.Mes == 12)
                    {
                        f.Mes = 0;
                        f.Años++;


                    }
                    Console.WriteLine("|" + f.Dia + "/" + ++f.Mes + "/" + f.Años + "|||" + o.cuota + "|||" + capital2 + "|||" + interes2 + "|||" + balance2); Console.WriteLine("|");
                    pago = ++pago;


                }
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("presiona (1)para volver a calcular");
                b = int.Parse(Console.ReadLine());
                if (b == 1)
                {
                    Console.Clear();
                    x = true;

                }
                else
                {
                    Console.WriteLine("presiona (1)para volver a calcular");
                    b = int.Parse(Console.ReadLine());

                }
            }
            Console.ReadKey();

        }
    }
}
