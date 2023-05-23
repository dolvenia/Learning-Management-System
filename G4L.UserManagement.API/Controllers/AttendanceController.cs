using G4L.UserManagement.API.Authorization;
using G4L.UserManagement.BL.Entities;
using G4L.UserManagement.BL.Enum;
using G4L.UserManagement.BL.Interfaces;
using G4L.UserManagement.BL.Models;
using G4L.UserManagement.DA.Services;
using G4L.UserManagement.Infrustructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace G4L.UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly ILogger<AttendanceController> _logger;
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(ILogger<AttendanceController> logger, IAttendanceService attendanceService)
        {
            _logger = logger;
            _attendanceService = attendanceService;
        }
        [Authorize(Role.Admin, Role.Learner, Role.Super_Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateAttendanceAsync([FromBody] Attendance_Register attendanceRegister)
        {
            await _attendanceService.SigningAttendanceRegisterAsync(attendanceRegister);
            return Ok(attendanceRegister);
        }

        [Authorize(Role.Admin,Role.Super_Admin)]
        [HttpPut]
        public async Task<IActionResult> UpdateAttendanceAsync([FromBody] UpdateAttendance updateAttendance)
        {
            await _attendanceService.UpdateAttendanceGoalsAsync(updateAttendance);
            return Ok();
        }

        [Authorize(Role.Super_Admin, Role.Admin, Role.Trainer, Role.Learner)]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAttendanceByUserIdAsync(Guid userId)
        {
            var attendanceRegister = await _attendanceService.GetAttendanceRegisterAsync(userId);
            return Ok(attendanceRegister);
        }
        [Authorize(Role.Super_Admin, Role.Admin, Role.Trainer)]
        [HttpGet("pages")]
        public async Task<IActionResult> GetBypagination(int skip = 0, int take = 5)
        {
            return Ok(await _attendanceService.GetPagedAttendancesAsync(skip, take));
        }
    }
}
