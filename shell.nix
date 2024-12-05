{pkgs ? import <nixpkgs> {}}:
pkgs.mkShell {
  # Packages
  packages = with pkgs; [
    # C#
    (with dotnetCorePackages; combinePackages [
      sdk_6_0
      sdk_7_0
    ])
    csharpier

    # Python
    (pkgs.python3.withPackages (python-pkgs: with python-pkgs; [
      # select Python packages here
      pandas
      requests
    ]))
  ];

  # C# Environment
  LD_LIBRARY_PATH = "$LD_LIBRARY_PATH:${pkgs.dotnetCorePackages.sdk_7_0}/lib";
  PATH = "$PATH:/home/alex/.dotnet/tools";
  DOTNET_ROOT = "${pkgs.dotnetCorePackages.sdk_7_0}";

  # Python Environment
  # ...
}