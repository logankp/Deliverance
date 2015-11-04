# Deliverance
Deliverance is a free, open-source library for reading and (eventually) writing .MSG files in the .NET Framework.

It is a 100% managed library that makes it easy to deal with "structured storage" Outlook files without having to use COM libraries.

### Status
Deliverance can get the following properties from an MSG file:
- [x] Recipients
- [x] From Address and Display name
- [x] Subject
- [x] Plain-text body
- [x] HTML body
- [ ] Attachments

### Building
Clone the project, open and build the solution in Visual Studio.

### Using
The following code snippet will show an example of how to use this library:

```cs
MsgFile msg = new MsgFile();
msg.Load(filePath);
Console.WriteLine("From Address: {0}", msg.Recipients[0].EmailAddress);
Console.WriteLine("From Name: {0}", msg.Recipients[0].DisplayName);
Console.WriteLine("Recipient Type: {0}", msg.Recipients[0].RecipientType);
Console.WriteLine("From: {0} ({1})", msg.FromName, msg.FromAddress);
Console.WriteLine("Subject: {0}", msg.Subject);
Console.WriteLine("Body: {0}", msg.Body);
```
### Dependencies

The following third-party libraries are used:

- OpenMCDF 2.0 (http://openmcdf.sourceforge.net/) MPL 2.0
- NUnit 2.6.4 (http://www.nunit.org/) NUnit License
- Crc32 (http://damieng.com/blog/2006/08/08/calculating_crc32_in_c_and_net) Apache 2.0

### License
Deliverance is licensed under the MIT License.