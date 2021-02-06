using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwentyFour.Models;
using TwentyFour.Services;

namespace TwentyFour.WebAPI.Controllers
{
    [Authorize]
    public class ReplyController : ApiController
    {
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }
        public IHttpActionResult Get()
        {
            ReplyService ReplyService = CreateReplyService();
            var replies = ReplyService.GetReplies();
            return Ok(replies);
        }
        public IHttpActionResult Reply(ReplyCreate Reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.CreateReply(Reply))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            ReplyService ReplyService = CreateReplyService();
            var reply = ReplyService.GetReplyById(id);
            return Ok(reply);
        }
        //public IHttpActionResult Put(ReplyEdit Reply)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreateReplyService();

        //    if (!service.UpdateReply(Reply))
        //        return InternalServerError();

        //    return Ok();
        //}
        //public IHttpActionResult Delete(int id)
        //{
        //    var service = CreateReplyService();

        //    if (!service.DeleteReply(id))
        //        return InternalServerError();

        //    return Ok();
        //}
    }
}
