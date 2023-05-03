using Moq;
using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Business.Services;
using WSServicioPichincha.Controllers;
using WSServicioPichincha.Data.Interfaces;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Tests
{
    public class ClienteTest
    {

        Mock<IClienteService> _mockIClienteService;
        Mock<IRepository<Cliente>> _mockIRepositoryCliente;
        Mock<IRepository<Persona>> _mockIRepositoryPersona;
        Cliente cliente;
        [OneTimeSetUp]
        public void Setup()
        {
            _mockIClienteService = new Mock<IClienteService>();
            _mockIRepositoryCliente = new Mock<IRepository<Cliente>>();
            _mockIRepositoryPersona = new Mock<IRepository<Persona>>();
            cliente = new Cliente();
        }

        [Test]
        public void TestSaveCliente()
        {
            _mockIClienteService.Setup(x => x.Save(It.IsAny<Cliente>())).ReturnsAsync(new Cliente());
            ClienteController ClienteController = new ClienteController(_mockIClienteService.Object);
            Assert.DoesNotThrowAsync(async () => await ClienteController.Post(cliente));
        }
        [Test]
        public void TestUpdateCliente()
        {
            _mockIClienteService.Setup(x => x.Update(It.IsAny<Cliente>())).ReturnsAsync(new Cliente());
            ClienteController ClienteController = new ClienteController(_mockIClienteService.Object);
            Assert.DoesNotThrowAsync(async () => await ClienteController.Put(cliente));
        }
        [Test]
        public void TestDeleteCliente()
        {
            _mockIClienteService.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(new Cliente());
            ClienteController ClienteController = new ClienteController(_mockIClienteService.Object);
            Assert.DoesNotThrowAsync(async () => await ClienteController.Delete(1));
        }
        [Test]
        public void TestSaveClienteService()
        {
            _mockIClienteService.Setup(x => x.Save(It.IsAny<Cliente>())).ReturnsAsync(new Cliente());
            _mockIRepositoryPersona.Setup(x => x.Save(It.IsAny<Persona>())).ReturnsAsync(new Persona());
            _mockIRepositoryPersona.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new Persona());
            ClienteService ClienteService = new ClienteService(_mockIRepositoryCliente.Object, _mockIRepositoryPersona.Object);
            Assert.DoesNotThrowAsync(async () => await ClienteService.Save(cliente));
        }
        [Test]
        public void TestUpdateClienteService()
        {
            _mockIClienteService.Setup(x => x.Update(It.IsAny<Cliente>())).ReturnsAsync(new Cliente());
            _mockIRepositoryPersona.Setup(x => x.Save(It.IsAny<Persona>())).ReturnsAsync(new Persona());
            _mockIRepositoryPersona.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(new Persona());
            ClienteService ClienteService = new ClienteService(_mockIRepositoryCliente.Object, _mockIRepositoryPersona.Object);
            Assert.DoesNotThrowAsync(async () => await ClienteService.Update(cliente));
        }
        [Test]
        public void TestDeleteClienteService()
        {
            _mockIClienteService.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(new Cliente());
            _mockIRepositoryPersona.Setup(x => x.Save(It.IsAny<Persona>())).ReturnsAsync(new Persona());
            ClienteService ClienteService = new ClienteService(_mockIRepositoryCliente.Object, _mockIRepositoryPersona.Object);
            Assert.DoesNotThrowAsync(async () => await ClienteService.Delete(1));
        }
    }
}