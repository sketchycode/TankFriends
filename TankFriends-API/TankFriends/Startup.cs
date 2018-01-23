using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TankFriends.Models;
using TankFriends.Services;

namespace TankFriends
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<Player, IdentityRole>().AddEntityFrameworkStores<PlayerContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            services.AddDbContext<TankFriendsContext>(opt => opt.UseInMemoryDatabase("GameList"));
            services.AddDbContext<PlayerContext>(opt => opt.UseInMemoryDatabase("PlayerList"));
            services.AddTransient<PlayerService, PlayerService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
