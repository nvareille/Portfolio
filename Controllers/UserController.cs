﻿using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
	public class UserController : Controller
	{
		public UserController()
		{

		}

		private readonly UserRepository _userRepository;
		public UserController(UserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public IActionResult ViewRegister()
		{
			return View();
		}

		public IActionResult ViewLogin()
		{
			return View();
		}

		public static void CreateCookie(string key, string value, TimeSpan expiration)
		{
			_userRepository.CreateCookie(key, value, expiration);
		}

		public static string GetCookieValue(string key)
		{
			return _userRepository.GetCookieValue(key);
		}

		public bool IsAdmin(Users user)
		{
			return _userRepository.IsAdmin(user);
		}

		//public bool IsConnected(string token)
		//{

		//}

		public ActionResult Register(Users user)
		{
			_userRepository.Registrer(user);
			return RedirectToAction(nameof(ViewRegister));
		}

		public ActionResult Login(Users user)
		{
			_userRepository.Login(user);
			return RedirectToAction(nameof(ViewLogin));
		}
	}
}
