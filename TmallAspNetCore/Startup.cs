using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Reflection;

namespace TmallAspNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.0",
                    Title = "天猫商城 API",
                    Description = "天猫商城对外开放API接口",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "hncboy", Email = "619452863@qq.com", Url = "http://hncboy.top/" }
                });
                #region 读取xml信息
                c.IncludeXmlComments(string.Format("{0}/TmallAspNetCore.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                #endregion
            });
            #endregion

            #region AutoFac
            // 实例化 AutoFac  容器   
            var builder = new ContainerBuilder();
            // 通过反射将Tmall.Core.Services和Tmall.Core.Repository两个程序集的全部方法注入
            var assemblysServices = Assembly.Load("Tmall.Core.Services");
            // 指定已扫描程序集中的类型注册为提供所有其实现的接口
            builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();
            var assemblysRepository = Assembly.Load("Tmall.Core.Repository");
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();
            // 将services填充到Autofac容器生成器中
            builder.Populate(services);
            // 使用已进行的组件登记创建新容器
            var ApplicationContainer = builder.Build();
            #endregion

            // 第三方IOC接管 core内置DI容器
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });
            #endregion
        }
    }
}
