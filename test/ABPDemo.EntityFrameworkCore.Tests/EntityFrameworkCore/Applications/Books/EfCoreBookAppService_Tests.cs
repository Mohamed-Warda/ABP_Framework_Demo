using ABPDemo.Books;
using Xunit;

namespace ABPDemo.EntityFrameworkCore.Applications.Books;

[Collection(ABPDemoTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<ABPDemoEntityFrameworkCoreTestModule>
{

}