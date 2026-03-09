// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "For avoid xUnit1027.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure.TestServerCollectionFixture")]
[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "For avoid xUnit1027.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure.GenericInfrastructureTestServerFixture")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Test methods use underscores for readability.", Scope = "namespaceanddescendants", Target = "~N:GtMotive.Estimate.Microservice.InfrastructureTests.Specs")]
[assembly: SuppressMessage("Maintainability", "CA1515:Consider making public types internal", Justification = "For avoid xUnit1000.", Scope = "type", Target = "~T:GtMotive.Estimate.Microservice.InfrastructureTests.Specs.VehicleEndpointTests")]
