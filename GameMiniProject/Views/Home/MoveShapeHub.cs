using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using GameMiniProject.User;
using System.Data.Entity;
using System.Data;
using GameMiniProject.Models;

namespace WebApplication1.MoveShape
{
    [HubName("moveShape")]
    public class MoveShapeHub : Hub
    {
        private gameEntities db = new gameEntities();


        //When player connects, cycle through groups and count the amount of players in group,
        //if a group has only one player then join that group.
        //if the group has two players then create a new group.


        public override Task OnConnected()
        {
            Boolean foundgroup = false;

            var groupsList = db.Groups.ToList();


            foreach (var item in groupsList)
            {
                var playerCount = db.Players.Where(x => x.GroupId == item.GroupId).Count();
                if (playerCount == 1)
                {
                    var newPlayer = new Player();
                    newPlayer.PlayerId = 4575;
                    newPlayer.UserId = Context.User.Identity.Name;
                    newPlayer.SignalConnectionId = Context.ConnectionId;
                    newPlayer.GroupId = item.GroupId;
                    db.Players.Add(newPlayer);

                    db.SaveChanges();

                    foundgroup = true;
                    //Groups.Add(Context.ConnectionId, Convert.ToString(item.GroupId));

                    Clients.Caller.getPlayer(2);

                }


            }
            if (foundgroup == false)
            {
                Groups.Add(Context.ConnectionId, Convert.ToString(groupsList.Count + 1));
                var newGroup = new Group();
                //newGroup.GroupId = Convert.ToInt16( (groupsList.Count + 1));
                newGroup.DateCreated = DateTime.Now;
                newGroup.GroupName = "Test";
                db.Groups.Add(newGroup);
                db.SaveChanges();

                var newPlayer = new Player();
                newPlayer.UserId = Context.User.Identity.Name;
                newPlayer.PlayerId = 1;
                newPlayer.SignalConnectionId = Convert.ToString( Context.ConnectionId);
                newPlayer.GroupId = (groupsList.Count + 1);

                db.Players.Add(newPlayer);
                db.SaveChanges();
                Clients.Caller.getPlayer(1);

            }


            return base.OnConnected();
        }
        public void healthCounter(int currentHealth)
        {
            Clients.All.calculateHealth(currentHealth);

        }

        //need to fix

        public void MoveShape(int x, int y)
        {
            //var player = new Player();
            //player = db.Players.SingleOrDefault(i => i.SignalConnectionId == Context.ConnectionId);

            //Clients.Group(Convert.ToString(player.GroupId)).shapeMoved(x, y); 
            Clients.All.shapeMoved(x, y);
        }

        public void MoveShape2(int x, int y)
        {
            //var player2 = new Player();
            //player2 = db.Players.SingleOrDefault(i => i.SignalConnectionId == Context.ConnectionId);

            //Clients.Group(Convert.ToString(player2.GroupId)).shapeMoved2(x, y); 
            Clients.All.shapeMoved2(x, y);

        }

    }
}
