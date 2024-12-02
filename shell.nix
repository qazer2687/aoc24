{pkgs ? import <nixpkgs> {}}:
pkgs.mkShell {
  # Packages
  packages = with pkgs; [
    (with dotnetCorePackages; combinePackages [
      sdk_6_0
      sdk_7_0
    ])
    csharpier
  ];

  # Environment
  LD_LIBRARY_PATH = "$LD_LIBRARY_PATH:${pkgs.dotnetCorePackages.sdk_7_0}/lib";
  PATH = "$PATH:/home/alex/.dotnet/tools";
  DOTNET_ROOT = "${pkgs.dotnetCorePackages.sdk_7_0}";
}
