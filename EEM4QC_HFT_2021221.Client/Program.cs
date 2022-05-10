using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EEM4QC_HFT_2021221.Models;

namespace EEM4QC_HFT_2021221.Client
{
    public class HrEmployee
    {

        public int Emp_Id { get; set; }
        public string Emp_Name { get; set; }
        public string Emp_Surname { get; set; }
        public bool Emp_Is_Existed { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowHrEmployee(HrEmployee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            Console.WriteLine($"Emp_Name: {employee.Emp_Name}\tEmp_Surname: " +
                $"{employee.Emp_Surname}\tEmp_Is_Existed: {employee.Emp_Is_Existed}");
        }

        static async Task<HttpResponseMessage> CreateHrEmployeeAsync(HrEmployee employee)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "Employee/Create", employee);
            response.EnsureSuccessStatusCode();
            return response;
        }

        static async Task<HrEmployee> GetHrEmployeeAsync(string path, int empId)
        {
            HrEmployee employee = null;
            HttpResponseMessage response = await client.GetAsync(path+ $"Employee/Get/{empId}");
            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<HrEmployee>();
            }
            return employee;
        }

        static async Task<HrEmployee> UpdateHrEmployeeAsync(HrEmployee employee)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"Employee/Update/{employee.Emp_Id}", employee);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated employee from the response body.

            employee = await response.Content.ReadAsAsync<HrEmployee>();
            return employee;
        }

        static async Task<HttpStatusCode> DeleteHrEmployeeAsync(int employee_id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"Employee/Delete/{employee_id}");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {

           

            client.BaseAddress = new Uri("http://localhost:25793/api/EEM4QC_HFT_2021221.Endpoint/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new employee
                //Creating new employee and get the new id and store into empCreate Variable 
                HrEmployee employee = new HrEmployee
                {
                    Emp_Name = "Aynur",
                    Emp_Surname = "Abdul",
                    Emp_Is_Existed = true
                };

                var respones = await CreateHrEmployeeAsync(employee);

                Console.WriteLine($"Created at {respones.RequestMessage.RequestUri}");
                var empCreated = await respones.Content.ReadAsAsync<HrEmployee>();
                // Get the employee
                employee = await GetHrEmployeeAsync(client.BaseAddress?.PathAndQuery, empCreated.Emp_Id);
                if (employee is null)
                {
                    throw new ArgumentNullException(nameof(employee));
                }
                ShowHrEmployee(employee);

                // Update the employee

                //Update the employee surname 
                Console.WriteLine("Updating Surname");
                employee.Emp_Surname = "Abdull";

                await UpdateHrEmployeeAsync(employee);

                // Get the updated employee

                employee = await GetHrEmployeeAsync(client.BaseAddress?.PathAndQuery, empCreated.Emp_Id);
                ShowHrEmployee(employee);

                // Delete the employee
                //delete the employee
                var statusCode = await DeleteHrEmployeeAsync(empCreated.Emp_Id);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");
                Console.WriteLine($"Employee Id {empCreated.Emp_Id} deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}