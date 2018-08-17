using EntityFrameworkCore.Models;
using System;
using System.Linq;
using System.Transactions;

namespace entFrExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            testefcoreContext.ConnectionString = "Server=localhost;Database=testefcore;User Id=sa;Password=123456;";

            try
            {
                //deleteing all
                Console.WriteLine("Deleting...");
                using (TransactionScope scope = new TransactionScope())
                using (var dbctx = new testefcoreContext())
                {
                    foreach (var item in dbctx.Personas.ToList())
                    {
                        dbctx.Personas.Remove(item);
                        Console.WriteLine("Deleted Person: {0}", item.Id);
                    }

                    foreach (var item in dbctx.Movimientos.ToList())
                    {
                        dbctx.Movimientos.Remove(item);
                        Console.WriteLine("Deleted Movement: {0}", item.Id);
                    }

                    dbctx.SaveChanges();
                    scope.Complete();
                }

                //insert
                Console.WriteLine("Inserting...");
                using (TransactionScope scope = new TransactionScope())
                using (var dbctx = new testefcoreContext())
                {
                    Personas p1 = new Personas()
                    {
                        Estado = 1,
                        FehcaNacimiento = DateTime.Now,
                        Nombre = "Joseph"
                    };
                    dbctx.Personas.Add(p1);                    

                    Personas p2 = new Personas()
                    {
                        Estado = 2,
                        FehcaNacimiento = DateTime.Now.AddMonths(-24),
                        Nombre = "Pepe"
                    };
                    dbctx.Personas.Add(p2);

                    dbctx.SaveChanges(); //to get the persons id's 
                    Console.WriteLine("Added Person: {0}", p1.Id);
                    Console.WriteLine("Added Person: {0}", p2.Id);

                    Movimientos m1 = new Movimientos()
                    {
                        Fecha = DateTime.Now,
                        IdPersona = p1.Id,
                        Importe = 23.99m,                        
                    };
                    dbctx.Movimientos.Add(m1);

                    Movimientos m2 = new Movimientos()
                    {
                        Fecha = DateTime.Now,
                        IdPersona = p1.Id,
                        Importe = 1001m,
                    };
                    dbctx.Movimientos.Add(m2);

                    Movimientos m3 = new Movimientos()
                    {
                        Fecha = DateTime.Now,
                        IdPersona = p2.Id,
                        Importe = 0.36m,
                    };
                    dbctx.Movimientos.Add(m3);

                    dbctx.SaveChanges();
                    Console.WriteLine("Added Movement: {0}", m1.Id);
                    Console.WriteLine("Added Movement: {0}", m2.Id);
                    Console.WriteLine("Added Movement: {0}", m3.Id);

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("End");
                Console.ReadKey();
            }
            
        }
    }
}
