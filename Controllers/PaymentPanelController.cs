using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Model;
using ParkingApp.Model.DTO;
using ParkingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Controllers
{
    [ApiController]
    [Route("api/paymentpanel")]
    public class PaymentPanelController : AppController
    {
        private readonly IPaymentPanelRepository paymentPanelRepository;
        private readonly IMapper mapper;

        public PaymentPanelController(
            IPaymentPanelRepository paymentPanelRepository,
            IMapper mapper
        )
        {
            this.paymentPanelRepository = paymentPanelRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentPanelDetailDTO>> GetPaymentPanel()
        {
            var paymentPanel = this.paymentPanelRepository.GetAll();
            var paymentPanelDTO = this.mapper.Map<IEnumerable<PaymentPanelDetailDTO>>(paymentPanel);
            return Ok(paymentPanelDTO);
        }
        [HttpGet("{id}")]
        public ActionResult<PaymentPanelDetailDTO> GetPaymentPanel(long id)
        {
            var paymentPanel = this.paymentPanelRepository.GetOne(id);
            var paymentPanelDTO = this.mapper.Map<PaymentPanelDetailDTO>(paymentPanel);
            return Ok(paymentPanelDTO);
        }
        [HttpPost]
        public ActionResult<PaymentPanelDetailDTO> CreatePaymentPanel(PaymentPanelCreateDTO paymentPanelDTO)
        {
            var paymentPanel = this.mapper.Map<PaymentPanel>(paymentPanelDTO);
            paymentPanel = this.paymentPanelRepository.CreatePaymentPanel(paymentPanel);
            return this.mapper.Map<PaymentPanelDetailDTO>(paymentPanel);
        }
        [HttpDelete("{id}")]
        public ActionResult<object> DeletePaymentPanel(long id)
        {
            return new { success = this.paymentPanelRepository.DeletePaymentPanel(id) };
        }
        [HttpPut("{id}")]
        public ActionResult<PaymentPanelDetailDTO> UpdatePaymentPanel(long id, [FromBody] PaymentPanel updatedPaymentPanel)
        {
            var paymentPanel = this.paymentPanelRepository.UpdatePaymentPanel(id, updatedPaymentPanel);
            var paymentPanelResult = this.mapper.Map<PaymentPanelDetailDTO>(paymentPanel);
            return paymentPanelResult;
        }
    }
}