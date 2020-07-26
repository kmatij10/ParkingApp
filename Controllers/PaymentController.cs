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
    [Route("api/payment")]
    public class PaymentController : AppController
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IMapper mapper;

        public PaymentController(
            IPaymentRepository paymentRepository,
            IMapper mapper
        )
        {
            this.paymentRepository = paymentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentDetailDTO>> GetPayment()
        {
            var payment = this.paymentRepository.GetAll();
            var paymentDTO = this.mapper.Map<IEnumerable<PaymentDetailDTO>>(payment);
            return Ok(paymentDTO);
        }
        [HttpGet("{id}")]
        public ActionResult<PaymentDetailDTO> GetPayment(long id)
        {
            var payment = this.paymentRepository.GetOne(id);
            var paymentDTO = this.mapper.Map<PaymentDetailDTO>(payment);
            return Ok(paymentDTO);
        }
        [HttpPost]
        public ActionResult<PaymentDetailDTO> CreatePayment(PaymentCreateDTO paymentDTO)
        {
            var payment = this.mapper.Map<Payment>(paymentDTO);
            payment = this.paymentRepository.CreatePayment(payment);
            return this.mapper.Map<PaymentDetailDTO>(payment);
        }
        [HttpDelete("{id}")]
        public ActionResult<object> DeletePayment(long id)
        {
            return new { success = this.paymentRepository.DeletePayment(id) };
        }
        [HttpPut("{id}")]
        public ActionResult<PaymentDetailDTO> UpdatePayment(long id, [FromBody] Payment updatedPayment)
        {
            var payment = this.paymentRepository.UpdatePayment(id, updatedPayment);
            var paymentResult = this.mapper.Map<PaymentDetailDTO>(payment);
            return paymentResult;
        }
    }
}