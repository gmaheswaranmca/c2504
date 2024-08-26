1. AssemblyInfo.cs
```
[assembly: log4net.Config.XmlConfigurator]
```


2. App.config 
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<configSections>
		<section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
	</configSections>

	<log4net>
		<!-- File Appender -->
		<appender name="FileAppender" type="log4net.Appender.RollingFileAppender">
			<file value="week4assessment_app_log.log" />
			<appendToFile value="true" />
			<rollingStyle value="Size" />
			<maxSizeRollBackups value="5" />
			<maximumFileSize value="10MB" />
			<staticLogFileName value="true" />
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="%date [%thread] %-5level %logger - %message%newline" />
			</layout>
		</appender>

		<!-- Console Appender -->
		<appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender">
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="%date [%thread] %-5level %logger - %message%newline" />
			</layout>
		</appender>

		<!-- Root logger -->
		<root>
			<level value="ALL" />
			<appender-ref ref="FileAppender" />
			<appender-ref ref="ConsoleAppender" />
		</root>
	</log4net>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
    </startup>
</configuration>
```



3. Program.cs 
```
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace Week4AssessmentApp
{
    public class ServerException : Exception
    {
        public ServerException(string message) : base(message) { }
    }
    public class MedicationExpiry
    {
        public int BatchID { get; set; }
        public string Medication { get; set; }
        public DateTime ExpiryDate { get; set; }
        public override string ToString()
        {
            return $"[{BatchID},{Medication},{ExpiryDate}]";
        }
    }
    public class MedicationExpiryService
    {
        /*public static void Read(MedicationExpiry[] medicationExpiries)
        {
            for (int i = 0; i < medicationExpiries.Length; i++)
            {
                Console.WriteLine($"Enter details for medication {i + 1}:");
                Console.Write("BatchID: ");
                int batchID = int.Parse(Console.ReadLine());
                Console.Write("Medication: ");
                string medication = Console.ReadLine();
                Console.Write("ExpiryDate (yyyy-mm-dd): ");
                DateTime expiryDate = DateTime.Parse(Console.ReadLine());

                medicationExpiries[i] = new MedicationExpiry
                                        {
                                            BatchID = batchID,
                                            Medication = medication,
                                            ExpiryDate = expiryDate
                                        };
            }
        }*/
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Week4AssessmentDb;Integrated Security=True;";

        public static void Read(MedicationExpiry[] medicationExpiries)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT BatchID, Medication, ExpiryDate FROM MedicationExpiry";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();


                    for (int i = 0; i < medicationExpiries.Length; i++)
                    {
                        if (!reader.Read())
                        {
                            throw new ServerException("[0101]Server Errror.");//throw error
                        }
                        medicationExpiries[i] = new MedicationExpiry
                        {
                            BatchID = (int)reader["BatchID"],
                            Medication = reader["Medication"].ToString(),
                            ExpiryDate = (DateTime)reader["ExpiryDate"]
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                //Console.WriteLine($"SQL Error: {ex.Message}");
                throw new ServerException($"[0102]Server Errror.{ex.Message}");//throw Error
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //Console.WriteLine($"Error: {ex.Message}");
                throw new ServerException($"[0103]Server Errror.{ex.Message}");//throw Error
            }
        }
        public static void Sort(MedicationExpiry[] medicationExpiries)
        {
            for (int i = 0; i < medicationExpiries.Length - 1; i++)
            {
                for (int j = 0; j < medicationExpiries.Length - i - 1; j++)
                {
                    if (medicationExpiries[j].ExpiryDate > medicationExpiries[j + 1].ExpiryDate)
                    {
                        var temp = medicationExpiries[j];
                        medicationExpiries[j] = medicationExpiries[j + 1];
                        medicationExpiries[j + 1] = temp;
                    }
                }
            }
        }
        public static MedicationExpiry FindMin(MedicationExpiry[] medicationExpiries)
        {
            MedicationExpiry nearestExpiry = medicationExpiries[0];
            foreach (var med in medicationExpiries)
            {
                if (med.ExpiryDate < nearestExpiry.ExpiryDate)
                {
                    nearestExpiry = med;
                }
            }
            return nearestExpiry;
        }
        public static MedicationExpiry FindSecondMax(MedicationExpiry[] medicationExpiries)
        {
            DateTime max = DateTime.MinValue;
            DateTime secondMax = DateTime.MinValue;

            MedicationExpiry maxExpiry = null;
            MedicationExpiry secondMaxExpiry = null;

            foreach (var med in medicationExpiries)
            {
                if (med.ExpiryDate > max)
                {
                    if (max != DateTime.MinValue)
                    {
                        secondMaxExpiry = maxExpiry;
                        secondMax = secondMaxExpiry.ExpiryDate;
                    }
                    maxExpiry = med;
                    max = med.ExpiryDate;
                }
                else if (med.ExpiryDate > secondMax && med.ExpiryDate != max)
                {
                    secondMaxExpiry = med;
                    secondMax = secondMaxExpiry.ExpiryDate;
                }
            }
            return secondMaxExpiry;
        }
    }
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            //log.Debug(DateTime.MinValue);
            MedicationExpiry[] medicationExpiries = new MedicationExpiry[3];
            try
            { 
                MedicationExpiryService.Read(medicationExpiries);
            }
            catch(ServerException ex)
            {
                log.Error($"{ex.Message}");
            }
            MedicationExpiry min = MedicationExpiryService.FindMin(medicationExpiries);
            log.Info($"min={min}");
            MedicationExpiry secondMax = MedicationExpiryService.FindSecondMax(medicationExpiries);
            log.Info($"secondMax={secondMax}");
            MedicationExpiryService.Sort(medicationExpiries);
            string output = "";
            foreach(var e in medicationExpiries)
            {
                output += $"{e} ";
            }
            log.Info(output);
        }
    }
}
```


4. MedicationExpiryServiceTests.cs
```
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week4AssessmentApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4AssessmentApp.Tests
{
    [TestClass()]
    public class MedicationExpiryServiceTests
    {
        [TestMethod()]
        public void FindMin_Test()
        {
            MedicationExpiry[] medicationExpiries = new MedicationExpiry[3];
            MedicationExpiryService.Read(medicationExpiries);
            MedicationExpiry expected = new MedicationExpiry
                                {
                                    BatchID = 3,
                                    Medication = "Halls",
                                    ExpiryDate = DateTime.Parse("2025-05-31")
                                };
            MedicationExpiry actual = MedicationExpiryService.FindMin(medicationExpiries);
            Assert.AreEqual(expected.ToString(),actual.ToString());
        }
        [TestMethod()]
        public void FindSecondMax_Test()
        {
            MedicationExpiry[] medicationExpiries = new MedicationExpiry[3];
            MedicationExpiryService.Read(medicationExpiries);
            MedicationExpiry expected = new MedicationExpiry
                                {
                                    BatchID = 2,
                                    Medication = "Vicks",
                                    ExpiryDate = DateTime.Parse("2025-11-20")
                                };
            MedicationExpiry actual = MedicationExpiryService.FindSecondMax(medicationExpiries);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
        [TestMethod()]
        public void Sort_Test()
        {
            MedicationExpiry[] medicationExpiries = new MedicationExpiry[3];
            MedicationExpiryService.Read(medicationExpiries);
            MedicationExpiry expected = new MedicationExpiry
                                {
                                    BatchID = 3,
                                    Medication = "Halls",
                                    ExpiryDate = DateTime.Parse("2025-05-31")
                                };
            MedicationExpiryService.Sort(medicationExpiries);
            MedicationExpiry actual = medicationExpiries[0];
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
```