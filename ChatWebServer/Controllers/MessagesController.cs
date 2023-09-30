using ChatWebServer.DAL;
using ChatWebServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebServer.Controllers
{
    public class MessagesController : Controller
    {
        private readonly MessagesService _messagesService;
        public MessagesController(MessagesService MessageService)
        {
            _messagesService = MessageService;
        }

        [HttpGet]
        public async Task<List<Message>> Get() =>
        await _messagesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Message>> Get(string id)
        {
            var message = await _messagesService.GetAsync(id);

            if (message is null)
            {
                return NotFound();
            }

            return message;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Message newMessage)
        {
            await _messagesService.CreateAsync(newMessage);

            return CreatedAtAction(nameof(Get), new { id = newMessage.Id }, newMessage);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Message updatedMessage)
        {
            var message = await _messagesService.GetAsync(id);

            if (message is null)
            {
                return NotFound();
            }

            updatedMessage.Id = message.Id;

            await _messagesService.UpdateAsync(id, updatedMessage);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var message = await _messagesService.GetAsync(id);

            if (message is null)
            {
                return NotFound();
            }

            await _messagesService.RemoveAsync(id);

            return NoContent();
        }
    }
}