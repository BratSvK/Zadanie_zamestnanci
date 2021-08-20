using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyManagerAPI.DTOs;
using CompanyManagerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagerAPI.Interfaces
{

    // abstraction of our dbContext 
    public interface IEmployeeRepository
    {

        void Update(EmployeeDTO employee);


        Task<ActionResult<EmployeeDTO>> CreateEmploeyee(CreateEmploeyee emploeyee);


        Task<bool> RemoveEmploeyee(int emploeyeeId);

        Task<bool> SaveAllAsync();

        Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesAsync();

        Task<ActionResult<EmployeeDTO>> GetEmploeyeeByIdAsync(int id);

        Task<bool> EmploeyeeExists(int id);


        Task<bool> EmploeyeeShouldAddToOddelenie(int idOddelenie);


        
        
         
    }
}