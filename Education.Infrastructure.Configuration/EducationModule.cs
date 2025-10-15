using Autofac;
using Autofac.Extras.DynamicProxy;
using Education.Application;
using Education.Domain.BaseDataAgg.Service;
using Education.Domain.Shared.Acls.UserManagement;
using Education.Infrastructure.Acl;
using Education.Infrastructure.Persistence;
using Education.Infrastructure.Persistence.Repository;
using Education.Infrastructure.Query;
using Education.Presentation.Facade.Command;
using Education.Presentation.Facade.Query;
using Epc.Application.Command;
using Epc.Application.Query;
using Epc.Autofac;
using Epc.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Education.Infrastructure.Configuration;

public class EducationModule(string connectionString) : Module
{
    private string ConnectionString { get; set; } = connectionString;

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserManagementAclService>().As<IUserManagementAclService>();

        var repositoryAssembly = typeof(TrainingCourseRepository).Assembly;
        builder.RegisterAssemblyTypes(repositoryAssembly)
            .AsClosedTypesOf(typeof(IRepository<,>))
            .InstancePerLifetimeScope();

        var domainServiceAssembly = typeof(BaseDataService).Assembly;
        builder.RegisterAssemblyTypes(domainServiceAssembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces();

        var commandHandlersAssembly = typeof(BaseDataCommandHandler).Assembly;
        builder.RegisterAssemblyTypes(commandHandlersAssembly)
            .AsClosedTypesOf(typeof(ICommandHandler<>))
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(commandHandlersAssembly)
            .AsClosedTypesOf(typeof(ICommandHandler<,>))
            .InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(commandHandlersAssembly)
            .AsClosedTypesOf(typeof(ICommandHandlerAsync<>))
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(commandHandlersAssembly)
            .AsClosedTypesOf(typeof(ICommandHandlerAsync<,>))
            .InstancePerLifetimeScope();
        var queryHandlerAssembly = typeof(BaseDataQueryHandler).Assembly;
        builder.RegisterAssemblyTypes(queryHandlerAssembly)
            .AsClosedTypesOf(typeof(IQueryHandler<>))
            .InstancePerDependency();

        builder.RegisterAssemblyTypes(queryHandlerAssembly)
            .AsClosedTypesOf(typeof(IQueryHandlerAsync<>))
            .InstancePerDependency();

        builder.RegisterAssemblyTypes(queryHandlerAssembly)
            .AsClosedTypesOf(typeof(IQueryHandler<,>))
            .InstancePerDependency();

        builder.RegisterAssemblyTypes(queryHandlerAssembly)
            .AsClosedTypesOf(typeof(IQueryHandlerAsync<,>))
            .InstancePerDependency();
        if (!ConnectionString.Contains("Server"))
            ConnectionString = Encoding.UTF8.GetString(Convert.FromBase64String(ConnectionString));
        builder.Register(_ =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<EducationCommandContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new EducationCommandContext(optionsBuilder.Options);
        })
            .As<DbContext>()
            .As<EducationCommandContext>()
            .InstancePerLifetimeScope();

        builder.Register(_ =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<EducationQueryContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new EducationQueryContext(optionsBuilder.Options);
        })
            .As<EducationQueryContext>()
            .InstancePerDependency();

        var facadeAssembly = typeof(TrainingCourseCommandFacade).Assembly;
        builder.RegisterAssemblyTypes(facadeAssembly)
            .Where(t => t.Name.EndsWith("CommandFacade"))
            .InstancePerLifetimeScope()
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(SecurityInterceptor))
            .AsImplementedInterfaces();

        var facadeQueryAssembly = typeof(TrainingCourseQueryFacade).Assembly;
        builder.RegisterAssemblyTypes(facadeQueryAssembly)
            .Where(t => t.Name.EndsWith("QueryFacade"))
            .InstancePerLifetimeScope()
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(SecurityInterceptor))
            .AsImplementedInterfaces();

        //var aclServiceAssembly = typeof(UserManagementAclService).Assembly;
        //builder.RegisterAssemblyTypes(aclServiceAssembly)
        //    .Where(t => t.Name.EndsWith("AclService"))
        //    .AsImplementedInterfaces()
        //    .InstancePerLifetimeScope();

        base.Load(builder);
    }
}