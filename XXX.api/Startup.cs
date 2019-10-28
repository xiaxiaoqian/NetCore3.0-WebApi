using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace XXX.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // 用来向容器中注册服务,注册好的服务可以在其他地方进行调用
        public void ConfigureServices(IServiceCollection services)
        {
            //注册swagger服务,定义1个或者多个swagger文档
            services.AddSwaggerGen(s=> {
                //设置swagger文档相关信息
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "xxxWebApi文档",
                    Description = "这是一个简单的NetCore WebApi项目",
                    Version = "v1.0"
                });
            
                //获取xml注释文件的目录
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 启用xml注释
                s.IncludeXmlComments(xmlPath);
            });
            services.AddControllers(option=> {
                //设置异常过滤器
                option.Filters.Add(new MyExceptionFilter());
            });
            services.AddRouting();
        }

        // 用来配置中间件管道,即如何响应http请求.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            
            //从appsettings.json获取配置文件
            Common.AppSettings.SetAppSetting(Configuration.GetSection("AppSettings"));
            app.UseRouting();

            app.UseAuthorization();
            //启用swagger中间件
            app.UseSwagger(opt=> {
                //opt.RouteTemplate = "api/{controller=Home}/{action=Index}/{id?}";
            });
            //启用SwaggerUI中间件（htlm css js等），定义swagger json 入口
            app.UseSwaggerUI(s => {
                
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "xxxWebapi文档v1");

                //要在应用的根 (http://localhost:<port>/) 处提供 Swagger UI，请将 RoutePrefix 属性设置为空字符串：
                //s.RoutePrefix = string.Empty;
            });
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //     name: "default",
                //     pattern: "api/{controller}/{action}/{id?}");
                endpoints.MapControllers();
                
            });

            //app.UseForwardedHeaders(new ForwardedHeadersOptions
            //{
            //    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
            //});
        }
    }
}
