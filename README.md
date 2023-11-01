# Core Engine

An open-source game engine designed for fast 2D and 3D games written in .NET Core with support for NativeAOT.

## Features

The engine is early in development, but the following features are planned:

- [ ] 2D and 3D
- [ ] VR
- [ ] Cross-platform
- [ ] NativeAOT
- [ ] Rolling support for the latest .NET version

## Current Hurdles

* Assembly unloading
  * This can likely be done with an AssemblyLoadContext.
* Source generation for asset serialization
  * Roslyn enables this, but the implementation could be complex.
* Audio playback
  * This can likely be done with either FFMpeg or OpenAL.
* Input detection
  * This can likely be done with OpenTK.
* VR output
  * There are several C# bindings for OpenVR and OpenXR.
* User interface for the editor
  * This can likely be done with ImGui bindings.
* Full screen support
  * This needs further investigation.

## Notable Implementation Details

* Runs on .NET 8
* It is fully managed, except for native libraries.
  * This minimizes the performance cost of native interop.
* The editor runs on the JIT compiler.
* The runtime can run on the JIT compiler or NativeAOT.
* Right-handed coordinate system
* Json for asset and metadata serialization
* Lz4 and Brotli compression
* `is null` is the same as `== null`
* Property names are capitalized.
* Properties can be serialized.
* Built-in support for nuget packages.

## Notable Classes

* `SerializableObject` (abstract base class for all serializable types)
* `GameNode` (sealed class that represents a node in the scene graph)
* `Component` (abstract base class for all types that can be attached to a `GameNode`)
* `Behavior` (abstract base class for all components that can be disabled)
* `Transform` (component that represents a `GameNode`'s position, rotation, and scale)

Due to the design, any custom scripts can inherit directly from `Component`, `Behavior`, or `SerializableObject`. There is no fundamental difference between engine defined and user defined classes.

## Example Asset File

Asset:
```json
{
	"1": {
		"$type": "CoreEngine.GameNode"
	},
	"2": {
		"$type": "CoreEngine.Transform"
	}
}
```
Metadata:
```json
{
	"guid": "00000000000000000000000000000000"
}
```