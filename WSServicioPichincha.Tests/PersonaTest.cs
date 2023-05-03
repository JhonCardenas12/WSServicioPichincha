using Moq;
using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Business.Services;
using WSServicioPichincha.Controllers;
using WSServicioPichincha.Data.Interfaces;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Tests
{
    public class CuentaTest
    {

        Mock<ICuentaService> _mockICuentaService;
        Mock<IRepository<Cuenta>> _mockIRepositoryCuenta;
        Mock<IRepository<Cliente>> _mockIRepositoryCliente;
        Cuenta cuenta;
        [OneTimeSetUp]
        public void Setup()
        {
            _mockICuentaService = new Mock<ICuentaService>();
            _mockIRepositoryCuenta = new Mock<IRepository<Cuenta>>();
            _mockIRepositoryCliente = new Mock<IRepository<Cliente>>();
            cuenta = new Cuenta();
        }

        [Test]
        public void TestSaveCuenta()
        {
            _mockICuentaService.Setup(x => x.Save(It.IsAny<Cuenta>())).ReturnsAsync(new Cuenta());
            CuentaController CuentaController = new CuentaController(_mockICuentaService.Object);
            Assert.DoesNotThrowAsync(async () => await CuentaController.Post(cuenta));
        }
        [Test]
        public void TestUpdateCuenta()
        {
            _mockICuentaService.Setup(x => x.Update(It.IsAny<Cuenta>())).ReturnsAsync(new Cuenta());
            CuentaController CuentaController = new CuentaController(_mockICuentaService.Object);
            Assert.DoesNotThrowAsync(async () => await CuentaController.Put(cuenta));
        }
        [Test]
        public void TestDeleteCuenta()
        {
            _mockICuentaService.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(new Cuenta());
            CuentaController CuentaController = new CuentaController(_mockICuentaService.Object);
            Assert.DoesNotThrowAsync(async () => await CuentaController.Delete(1));
        }
        [Test]
        public void TestSaveCuentaService()
        {
            _mockIRepositoryCuenta.Setup(x => x.Update(It.IsAny<Cuenta>())).ReturnsAsync(new Cuenta());
            _mockIRepositoryCliente.Setup(x => x.Update(It.IsAny<Cliente>())).ReturnsAsync(new Cliente());
            _mockIRepositoryCliente.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new Cliente());
            CuentaService CuentaService = new CuentaService(_mockIRepositoryCuenta.Object, _mockIRepositoryCliente.Object);
            Assert.DoesNotThrowAsync(async () => await CuentaService.Save(cuenta));
        }
        [Test]
        public void TestUpdateCuentaService()
        {
            _mockIRepositoryCuenta.Setup(x => x.Update(It.IsAny<Cuenta>())).ReturnsAsync(new Cuenta());
            _mockIRepositoryCliente.Setup(x => x.Update(It.IsAny<Cliente>())).ReturnsAsync(new Cliente());
            _mockIRepositoryCliente.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new Cliente());
            CuentaService CuentaService = new CuentaService(_mockIRepositoryCuenta.Object, _mockIRepositoryCliente.Object);
            Assert.DoesNotThrowAsync(async () => await CuentaService.Update(cuenta));
        }
        [Test]
        public void TestDeleteCuentaService()
        {
            _mockIRepositoryCuenta.Setup(x => x.Update(It.IsAny<Cuenta>())).ReturnsAsync(new Cuenta());
            _mockIRepositoryCliente.Setup(x => x.Update(It.IsAny<Cliente>())).ReturnsAsync(new Cliente());
            CuentaService CuentaService = new CuentaService(_mockIRepositoryCuenta.Object, _mockIRepositoryCliente.Object);
            Assert.DoesNotThrowAsync(async () => await CuentaService.Delete(1));
        }
    }
}