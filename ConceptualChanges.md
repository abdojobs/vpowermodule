# Introduction #

vPowerModule is using a lot of different strategies than the original Veeam Powershell Snapin, both on the User side and on the Code side.


# User #

One major aspect of the user presentation is wanting to allow the use of Strings where ordinarily only more specific objects would function. This isn't necessarily a goal for our first release, but it is a goal for our final.

The idea here comes from the way that the VMWareCLI functions with flags like "-Container". There, you can either specify an actual container (such as a folder, or host, or vApp), or you can just supply the name of that container as a string (with appropriate errors for ambiguity).