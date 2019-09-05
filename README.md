# README

Demonstrate to use IoC(Autofac) for AspNet Mvc5 with AspNet Identity



## AspNetMvc5UsingAutofac Steps

- Install NuGet Packages

```powershell
Install-Package Autofac.Mvc5 -Version 4.0.2
Install-Package Autofac.Mvc5.Owin -Version 4.0.1
```

- Modify `IdentityModels.cs` and add `ApplicationUserStore`

```csharp
public class ApplicationUserStore : UserStore<ApplicationUser>
{
    public ApplicationUserStore(ApplicationDbContext context)
        : base(context)
    {
    }
}
```

- Modify IdentityConfig.cs to use ApplicationUserStore
- Modify Startup.cs to use Autofac
- Modify Startup.Auth.cs

```csharp
public partial class Startup
{
    public void Configuration(IAppBuilder app)
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
        builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
        builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
        builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
        builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
        builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();

        builder.RegisterControllers(typeof(MvcApplication).Assembly);

        var container = builder.Build();

        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        app.UseAutofacMiddleware(container);
        app.UseAutofacMvc();
        ConfigureAuth(app);
    }
}

```

- Modify Startup.Auth class

- Modify ApplicationUserManager

- Modify the AccountController

## AspNetMvc5WithoutIdentity Steps

- Install NuGet Packages

```powershell
Install-Package Autofac.Mvc5 -Version 4.0.2
```

- Update `Application_Start()` to add Autofac support