var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var buildDir      = Directory("./artifacts");
var solution      = "./src/DevopsAssignmentPrimeCheck/DevopsAssignmentPrimeCheck.sln";

// TASKS
Task("Clean")
	.Does(() =>
	{
		
		CleanDirectory(buildDir);
		CleanDirectory("./src/DevopsAssignmentPrimeCheck/DevopsAssignmentPrimeCheck/bin/Release/netcoreapp1.1");
	});

Task("RestorePackages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solution);
});	
	
Task("Build")
	.IsDependentOn("RestorePackages")
	.WithCriteria(IsRunningOnWindows)
	.Does(() =>
	{
	  MSBuild(solution, settings =>
        settings.SetConfiguration(configuration));
	});

Task("Run-Unit-Tests")
	  .IsDependentOn("Build")
	  .Does(() =>
	{
	  MSTest("./src/DevopsAssignmentPrimeCheck/DevopsAssignmentPrimeCheck.UnitTest.Test/bin/Debug/DevopsAssignmentPrimeCheck.UnitTest.dll");
	});
	
Task("CopyArtifacts")
	.IsDependentOn("Run-Unit-Tests")
	.Does(() => 
	{
		CopyFiles("./src/DevopsAssignmentPrimeCheck/DevopsAssignmentPrimeCheck/bin/Release/netcoreapp1.1/*.dll", buildDir);
	});
	
Task("Default")
	.IsDependentOn("CopyArtifacts");
	
RunTarget(target);