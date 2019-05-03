﻿// -------------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Aniket Kamble"/>
// ---------------------------------------------------------------------------------------------------------------------------
namespace FundooApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BusinessLayer.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// The notes creation
        /// </summary>
        private readonly INotes notesCreation;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="notesCreation">The notes creation.</param>
        public NotesController(INotes notesCreation)
        {
            this.notesCreation = notesCreation;
        }

        /// <summary>
        /// Creates the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>return result</returns>
        [HttpPost]
        [Route("addNotes")]
        public async Task<IActionResult> CreateNotes(Notes notesModel)
        {
            try
            {
                var result = await this.notesCreation.Create(notesModel);
                return this.Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.BadRequest();

            }
        }

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>return result</returns>
        [HttpDelete]
        [Route("deleteNotes/{id}")]
        public async Task<IActionResult> DeleteNotes(int id)
        {
            try
            {
                var result = await this.notesCreation.Delete(id);
                return this.Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>return result</returns>
        [HttpPut]
        [Route("updateNotes/{id}")]
        public async Task<IActionResult> UpdateNotes(Notes notesModel, int id)
        {
            try
            {
                var result = await this.notesCreation.Change(notesModel, id);
                return this.Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Views all.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>return notes</returns>
        [HttpGet]
        [Route("viewNotes/{UserId}")]
        public IActionResult ViewAll(Guid userId)
        {
            try
            {
                IList<Notes> note = this.notesCreation.AccessNotes(userId);
                return this.Ok(note);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return this.BadRequest();
            }
        }
    }
}