using Moq;
using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Business.Services;
using WSServicioPichincha.Controllers;
using WSServicioPichincha.Data.Interfaces;
using WSServicioPichincha.Domain.Entities;

namespace WSServicioPichincha.Tests
{
    public class PersonaTest
    {

        Mock<IPersonaService> _mockIPersonaService;
        Mock<IRepository<Persona>> _mockIRepositoryPersona;
        Persona persona;
        [OneTimeSetUp]
        public void Setup()
        {
            _mockIPersonaService = new Mock<IPersonaService>();
            _mockIRepositoryPersona = new Mock<IRepository<Persona>>();
            persona = new Persona();
        }

        [Test]
        public void TestSavePersona()
        {
            _mockIPersonaService.Setup(x => x.Save(It.IsAny<Persona>())).ReturnsAsync(new Persona());
            PersonaController personaController = new PersonaController(_mockIPersonaService.Object);
            Assert.DoesNotThrowAsync(async () => await personaController.Post(persona));
        }
        [Test]
        public void TestUpdatePersona()
        {
            _mockIPersonaService.Setup(x => x.Update(It.IsAny<Persona>())).ReturnsAsync(new Persona());
            PersonaController personaController = new PersonaController(_mockIPersonaService.Object);
            Assert.DoesNotThrowAsync(async () => await personaController.Put(persona));
        }
        [Test]
        public void TestDeletePersona()
        {
            _mockIPersonaService.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(new Persona());
            PersonaController personaController = new PersonaController(_mockIPersonaService.Object);
            Assert.DoesNotThrowAsync(async () => await personaController.Delete(1));
        }
        [Test]
        public void TestSavePersonaService()
        {
            _mockIPersonaService.Setup(x => x.Save(It.IsAny<Persona>())).ReturnsAsync(new Persona());
            PersonaService personaService = new PersonaService(_mockIRepositoryPersona.Object);
            Assert.DoesNotThrowAsync(async () => await personaService.Save(persona));
        }
        [Test]
        public void TestUpdatePersonaService()
        {
            _mockIPersonaService.Setup(x => x.Update(It.IsAny<Persona>())).ReturnsAsync(new Persona());
            PersonaService personaService = new PersonaService(_mockIRepositoryPersona.Object);
            Assert.DoesNotThrowAsync(async () => await personaService.Update(persona));
        }
        [Test]
        public void TestDeletePersonaService()
        {
            _mockIPersonaService.Setup(x => x.Delete(It.IsAny<int>())).ReturnsAsync(new Persona());
            PersonaService personaService = new PersonaService(_mockIRepositoryPersona.Object);
            Assert.DoesNotThrowAsync(async () => await personaService.Delete(1));
        }
    }
}