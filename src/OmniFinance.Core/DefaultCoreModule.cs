using Autofac;
using OmniFinance.Core.Interfaces;
using OmniFinance.Core.Services;

namespace OmniFinance.Core;

/// <summary>
/// An Autofac module that is responsible for wiring up services defined in the Core project.
/// </summary>
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<DeleteAccountProfileService>()
        .As<IDeleteAccountProfileService>().InstancePerLifetimeScope();
  }
}
