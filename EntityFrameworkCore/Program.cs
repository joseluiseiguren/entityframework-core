using EntityFrameworkCore.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Transactions;

namespace entFrExample
{
    class Program
    {
        //to read configuration file
        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            //configure configuration file
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            Console.WriteLine("Starting...");

            testefcoreContext.ConnectionString = Configuration["connectionString"];

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

                //select
                Console.WriteLine("Selecting...");
                using (var dbctx = new testefcoreContext())
                {
                    foreach (var item in dbctx.Personas.Where(p => p.Nombre.ToUpper().StartsWith("JO")).ToList())
                    {
                        dbctx.Personas.Remove(item);
                        Console.WriteLine("Select Person Name Starts With 'JO': {0}", item.Nombre);
                    }

                    foreach (var item in dbctx.Movimientos.Where(p => p.Importe > 10m).ToList())
                    {
                        dbctx.Movimientos.Remove(item);
                        Console.WriteLine("Select Movement Price more than $10: {0}", item.Importe);
                    }
                }

                //update
                Console.WriteLine("Updating...");
                using (TransactionScope scope = new TransactionScope())
                using (var dbctx = new testefcoreContext())
                {
                    //update persona
                    var persona = dbctx.Personas.Where(p => p.Nombre.ToUpper().Equals("PEPE")).FirstOrDefault();
                    persona.Nombre = "Jonas";

                    dbctx.Personas.Update(persona);

                    //update movements
                    foreach (var item in dbctx.Movimientos.ToList())
                    {
                        item.Importe = item.Importe * 1.50m;
                        dbctx.Movimientos.Update(item);                        
                    }

                    dbctx.SaveChanges();
                    scope.Complete();
                }

                //select
                Console.WriteLine("Selecting...");
                using (var dbctx = new testefcoreContext())
                {
                    foreach (var item in dbctx.Personas.Where(p => p.Nombre.ToUpper().StartsWith("JO")).ToList())
                    {
                        dbctx.Personas.Remove(item);
                        Console.WriteLine("Select Person Name Starts With 'JO': {0}", item.Nombre);
                    }

                    foreach (var item in dbctx.Movimientos.Where(p => p.Importe > 10m).ToList())
                    {
                        dbctx.Movimientos.Remove(item);
                        Console.WriteLine("Select Movement Price more than $10: {0}", item.Importe);
                    }
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
