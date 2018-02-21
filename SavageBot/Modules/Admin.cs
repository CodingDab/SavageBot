using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace SavageBot.Modules
{
    [Group("admin")]
    [RequireUserPermissionAttribute(Discord.GuildPermission.Administrator)]
    public class Admin : ModuleBase<SocketCommandContext>
    {

    }
}
