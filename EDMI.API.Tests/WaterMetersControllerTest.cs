﻿using EMDI.API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EDMI.API.Tests
{
    public class WaterMetersControllerTest : BaseTest
    {
        public WaterMetersControllerTest(CompositionRootFixture fixture) : base(fixture)
        {
        }

        /// <summary>
        /// Se comprueba que el método GET devuelva al menos un elemento
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Get()
        {
            var model = CreateModel();

            var smodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            // Act
            var response = await this.Fixture.Client.PostAsync("/api/WaterMeters", smodel);
            response.EnsureSuccessStatusCode();

            // Act
            response = await this.Fixture.Client.GetAsync("/api/WaterMeters");
            response.EnsureSuccessStatusCode();

            // Assert
            var content = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrWhiteSpace(content));

            var models = JsonConvert.DeserializeObject<ICollection<WaterMeterModel>>(content);

            Assert.NotNull(models);
            Assert.True(models.Count > 0);
        }

        /// <summary>
        /// Se comprueba que el método GET devuelva al menos un elemento
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetWaterMeter()
        {
            var model = CreateModel();

            var smodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            // Act
            var response = await this.Fixture.Client.PostAsync("/api/WaterMeters", smodel);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var newModel = JsonConvert.DeserializeObject<WaterMeterModel>(content);

            // Act
            response = await this.Fixture.Client.GetAsync("/api/WaterMeters/" + newModel.Id.ToString());
            response.EnsureSuccessStatusCode();

            // Assert
            content = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrWhiteSpace(content));

            model = JsonConvert.DeserializeObject<WaterMeterModel>(content);

            Assert.NotNull(model);
        }

        /// <summary>
        /// Se comprueba que el método POST inserte una entidad de la BD
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Post()
        {
            WaterMeterModel model = CreateModel();

            var smodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            // Act
            var response = await this.Fixture.Client.PostAsync("/api/WaterMeters", smodel);
            response.EnsureSuccessStatusCode();

            // Assert
            var content = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrWhiteSpace(content));

            var newModel = JsonConvert.DeserializeObject<WaterMeterModel>(content);
            Assert.True(newModel.Id > 0);
        }

        /// <summary>
        /// Se comprueba que el método POST que no inserte una entidad de la BD
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PostNOK()
        {
            var model = new WaterMeterModel
            {
                FirmwareVersion = "v." + RandomInt(1, 99).ToString(),
                State = RandomString(4)
            };

            var smodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            // Act
            var response = await this.Fixture.Client.PostAsync("/api/WaterMeters", smodel);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        /// Se comprueba que el método PUT modifica una entidad de la BD
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Put()
        {
            var model = CreateModel();

            var smodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            // Act
            var response = await this.Fixture.Client.PostAsync("/api/WaterMeters", smodel);
            response.EnsureSuccessStatusCode();

            // Assert
            var content = await response.Content.ReadAsStringAsync();

            var newModel = JsonConvert.DeserializeObject<WaterMeterModel>(content);

            string newSerialNumber = RandomString(6);

            newModel.SerialNumber = newSerialNumber;

            smodel = new StringContent(JsonConvert.SerializeObject(newModel), Encoding.UTF8, "application/json");

            // Act
            response = await this.Fixture.Client.PutAsync("/api/WaterMeters/" + newModel.Id, smodel);
            response.EnsureSuccessStatusCode();

            // Assert
            content = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrWhiteSpace(content));

            newModel = JsonConvert.DeserializeObject<WaterMeterModel>(content);
            Assert.Equal(newSerialNumber, newModel.SerialNumber);
        }

        /// <summary>
        /// Se comprueba que el método PUT no modifica una entidad de la BD
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PutNOK()
        {
            var model = new WaterMeterModel
            {
            };

            var smodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            // Act
            var response = await this.Fixture.Client.PutAsync("/api/WaterMeters/1", smodel);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        /// Se comprueba que el método PUT no modifica una entidad de la BD porque no existe
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task PutNotFound()
        {
            var model = CreateModel();

            model.Id = RandomInt(1000, 10000);

            var smodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            // Act
            var response = await this.Fixture.Client.PutAsync("/api/WaterMeters/" + model.Id.ToString(), smodel);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        /// <summary>
        /// Se comprueba que el método DELETE elimine una entidad de la BD
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Delete()
        {
            var model = CreateModel();

            var smodel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            // Act
            var response = await this.Fixture.Client.PostAsync("/api/WaterMeters", smodel);
            response.EnsureSuccessStatusCode();

            // Assert
            var content = await response.Content.ReadAsStringAsync();
            Assert.False(string.IsNullOrWhiteSpace(content));

            var newModel = JsonConvert.DeserializeObject<WaterMeterModel>(content);
            Assert.True(newModel.Id > 0);

            // Act
            response = await this.Fixture.Client.DeleteAsync($"/api/WaterMeters/{newModel.Id}");
            response.EnsureSuccessStatusCode();

            // Assert
            content = await response.Content.ReadAsStringAsync();
            Assert.True(string.IsNullOrWhiteSpace(content));

            // Act
            response = await this.Fixture.Client.GetAsync($"/api/WaterMeters/{newModel.Id}");
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }


        /// <summary>
        /// Create a new WaterMeter Model
        /// </summary>
        /// <returns></returns>
        private WaterMeterModel CreateModel()
        {
            return new WaterMeterModel
            {
                SerialNumber = RandomString(6),
                FirmwareVersion = "v." + RandomInt(1, 99).ToString(),
                State = RandomString(4)
            };
        }
    }
}

