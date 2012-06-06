using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace IDCardActiveX
{
    [ComImport, GuidAttribute("CB5BDC81-93C1-11CF-8F20-00805F2CD064")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IObjectSafe
    {
        [PreserveSig]
        void GetInterfaceSafeOptions(ref Guid id, [MarshalAs(UnmanagedType.U4)] ref int pdwSupportedOptions, [MarshalAs(UnmanagedType.U4)] ref int pdwEnabledOptions);

        [PreserveSig()]
        void SetInterfaceSafeOptions(ref Guid id, [MarshalAs(UnmanagedType.U4)] int dwOptionSetMask, [MarshalAs(UnmanagedType.U4)] int dwEnabledOptions);
    }
}
