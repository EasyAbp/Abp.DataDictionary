# Abp.DataDictionary

[![ABP version](https://img.shields.io/badge/dynamic/xml?style=flat-square&color=yellow&label=abp&query=%2F%2FProject%2FPropertyGroup%2FAbpVersion&url=https%3A%2F%2Fraw.githubusercontent.com%2FEasyAbp%2FAbp.DataDictionary%2Fmaster%2FDirectory.Build.props)](https://abp.io)
[![NuGet](https://img.shields.io/nuget/v/EasyAbp.Abp.DataDictionary.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.Abp.DataDictionary.Domain.Shared)
[![NuGet Download](https://img.shields.io/nuget/dt/EasyAbp.Abp.DataDictionary.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.Abp.DataDictionary.Domain.Shared)
[![GitHub stars](https://img.shields.io/github/stars/EasyAbp/Abp.DataDictionary?style=social)](https://www.github.com/EasyAbp/Abp.DataDictionary)

ABP 数据字典模块

## 1. 介绍

**Easy.Abp.Dictionary** 库集成了标准的数据字典管理接口(增/删/改/查)，同时提供了配套的字典值渲染组件。该组件支持自动(`Attribute`)识别对应 DTO 的字典规则，并动态填充 DTO 值(**反射**)。

## 2. 如何使用?

### 2.1 安装

开发人员可以通过 NuGet 搜索 `EasyAbp.Abp.DataDictionary.*` 安装相应的组件，整个模块由以下几个包组成:

| 包名                                                    | 备注 |
| ------------------------------------------------------- | ---- |
| EasyAbp.Abp.DataDictionary.Application.Contracts.Shared |      |
| EasyAbp.Abp.DataDictionary.Application.Contracts        |      |
| EasyAbp.Abp.DataDictionary.Application                  |      |
| EasyAbp.Abp.DataDictionary.Domain.Shared                |      |
| EasyAbp.Abp.DataDictionary.Domain                       |      |
| EasyAbp.Abp.DataDictionary.EntityframeworkCore          |      |
| EasyAbp.Abp.DataDictionary.HttpApi                      |      |
| EasyAbp.Abp.DataDictionary.HttpApi.Client               |      |

对应的 NuGet 包分别安装到 ABP vNext 项目的不同分层，并依赖对应的模块。

### 2.2 配置

当前版本的所有配置都存放在 `AbpDataDictionaryOptions` 类中，开发人员可以在模块的 `ConfigureServie()` 或 `PreConfigureService()` 生命周期，使用 `Configure<TOptions>(TOptions option)` 方法配置对应的参数。

例子:

```csharp
public class DemoModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDataDictionaryOptions>(op =>
        {
            op.Rules.Add(new DataDictionaryRule
            {
                DictionaryCode = "字典类型编码",
                DictionaryCodeProperty = null, // 字典类型编码的字段。
                DtoType = null, // 输出 DTO 的类型。
                RenderFieldProperty = null // 需要填充字典值(文本)的字段。
            });
        });
    }
}
```

除了上面这种手动配置的方式以外，开发人员也可以在 DTO 标注特性来提供转换规则。

```csharp
public class WaitCacheRenderDto
{
    [DictionaryCodeField("XL")]
    public string Level { get; set; }

    [DictionaryRenderField]
    public string LevelValue { get; set; }
}
```

上述代码表明 `Level` 字段存放的是字典值编码，它归属于 `XL` 字典，渲染具体字典值的时候，将 `Level` 编码对应的文字性描述赋值给 `LevelValue` 字段。当然你可以将两个特性都标注到 `Level` 上，这样新的值会直接复制给 `Level`。

## 3. 概念/术语

Todo

## 4. 路线图

- [ ] 编写 ASP.NET Core MVC Filter 和 Middleware 统一处理响应 DTO。
- [ ] 缓存 Property Info 提升性能。