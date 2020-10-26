using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessInterface = AddressBookBusinessLib.Interface;
using BusinessModel = AddressBookBusinessLib.Model;

namespace AddressBook.WebApi.Controllers
{
    /// <summary>
    /// Contact Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DreeItemController : ControllerBase
    {
        BusinessInterface.IDreeItemRepository dreeItemRepository;

        /// <summary>
        /// DreeItem Controller
        /// </summary>
        /// <param name="dreeItemRepository">DreeItem Repository Interface</param>
        public DreeItemController(BusinessInterface.IDreeItemRepository dreeItemRepository)
        {
            this.dreeItemRepository = dreeItemRepository;
        }
        
        /// <summary>
        /// Get All Active Contact Records
        /// </summary>
        /// <returns>Array of Contact Objects</returns>
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<BusinessModel.DreeItem>> Get()
        {
            return dreeItemRepository.ReadAll().ToList();
        }

        /// <summary>
        /// Get Contact Record for provided record id
        /// </summary>
        /// <param name="id">Record of the contact record which has to be reterived</param>
        /// <returns>Contact record object for the provided id</returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<BusinessModel.DreeItem> Get(int id)
        {
            return dreeItemRepository.Read(id);
        }


        /// <summary>
        /// Use to save any new Contact entry
        /// </summary>
        /// <param name="contact">Contact object provided to be created as new entry</param>
        /// <returns>Status OK when successfully created and Not Found when the creation failed</returns>
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] BusinessModel.DreeItem dreeItem)
        {
            if (dreeItemRepository.Create(dreeItem))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Use to update any existing Contact record
        /// </summary>
        /// <param name="id">Record of existing contact record</param>
        /// <param name="contact">Contact changes encapsulated as contact object which has to be updated</param>
        /// <returns>Status OK when the update is successful and Not Found when the operation is failed</returns>
        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BusinessModel.DreeItem dreeItem)
        {
            dreeItem.Id = id;
            if (dreeItemRepository.Update(dreeItem))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Use to delete any existing Contact Record
        /// </summary>
        /// <param name="id">Record Id of existing contact record which is required to be deleted</param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dreeItemRepository.Delete(id);
        }
    }
}
