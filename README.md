##About LeanCloud
[LeanCloud](https://github.com/leancloud/leancloud-sdk)

LeanCloud 官方 只提供.NetFrame4.5的SDK ,不支持XP。本项目基于.NET Framework 4.0。

The offical SDK is not support Xp. This SDK base on .NET Framework 4 .

##About Project

只是实现登录，调用云函数，捕捉异常。

you can login ,call the cloud function and catch Exception .

##Notice

项目使用了一下引用

This project use these reference：

Microsoft.Bcl version="1.1.10" 

Microsoft.Bcl.Async version="1.0.168" 

Microsoft.Bcl.Build version="1.0.14" 

Microsoft.Net.Http version="2.2.29" 

Newtonsoft.Json version="8.0.2" 

如果要异步调用云函数，请安装相同版本的Microsoft.Bcl，Microsoft.Bcl.Build， Microsoft.Bcl.Async。或者[参考](http://stackoverflow.com/questions/17180268/warning-all-projects-referencing-myproject-csproj-must-install-nuget-package-m)禁止提示。

if you want to call the asynchronous methods， you need to add Microsoft.Bcl，Microsoft.Bcl.Build， Microsoft.Bcl.Async (same version). Or use this  to disable the warmning.

 Maybe you should add follow code in app.config.
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="System.Runtime" publicKeyToken="b03f5f7f11d50a3a" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-2.6.10.0" newVersion="2.6.10.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Threading.Tasks" publicKeyToken="b03f5f7f11d50a3a" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-2.6.10.0" newVersion="2.6.10.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Net.Http" publicKeyToken="b03f5f7f11d50a3a" culture="neutral" />
        <bindingRedirect oldVersion="0.0.0.0-2.2.29.0" newVersion="2.2.29.0" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
</configuration>

## Powered By yaco
