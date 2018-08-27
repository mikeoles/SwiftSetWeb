﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SwiftSetWeb.Models;

namespace SwiftSetWeb.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly SwiftSetContext _context;
        private static readonly String fullUrl = "youtube.com/watch?v=";
        private static readonly String shortUrl = "youtu.be/";

        public ExercisesController(SwiftSetContext context)
        {
            _context = context;
        }

        // GET: Exercises
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exercises.ToListAsync());
        }

        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercises = await _context.Exercises
                .SingleOrDefaultAsync(m => m.Id == id);
            if (exercises == null)
            {
                return NotFound();
            }
            YoutubeData videoData = parseYoutubeUrl(exercises.Url);

            ViewBag.embedCode = videoData.videoCode;
            ViewBag.embedTimeSeconds = (videoData.startTimeMillis/1000).ToString();

            return View(exercises);
        }

        private bool ExercisesExists(int id)
        {
            return _context.Exercises.Any(e => e.Id == id);
        }

        //Finds the start time and video code of a youtube video and returns it as a YoutubeData class
        public static YoutubeData parseYoutubeUrl(String selectedUrl)
        {
            //separate the youtube video code and time from the url
            String youtubeCode = "", videoCode;
            int startTimeMillis = 0;

            if (selectedUrl.ToLower().Contains(fullUrl))
            {//different depending on youtube.com and youtu.be urls
                youtubeCode = selectedUrl.Substring(selectedUrl.LastIndexOf(fullUrl) + fullUrl.Length);
            }
            else if (selectedUrl.ToLower().Contains(shortUrl))
            {
                youtubeCode = selectedUrl.Substring(selectedUrl.LastIndexOf(shortUrl) + shortUrl.Length);
            }
            else
            {
                //TODO handle badUrl
            }

            //Find the video code from the url
            //Ex: Url = https://www.youtube.com/watch?v=D5d_rkxPfuE&t=1m4s videoCode = D5d_rkxPfuE
            int endOfVideoCode = findFirstSeperator(youtubeCode);
            videoCode = youtubeCode.Substring(0, endOfVideoCode);
            //If a specific time is designated in the video set the start time in milliseconds
            if ((youtubeCode.Contains("&t=") || youtubeCode.Contains("?t=")) && (endOfVideoCode < youtubeCode.Length))
            {
                //removes the video code from the youtubeCode
                youtubeCode = youtubeCode.Substring(endOfVideoCode);
                //Timecode is everything after t=
                String timecode = "";
                if (youtubeCode.Contains("&t="))
                {
                    timecode = youtubeCode.Substring(youtubeCode.IndexOf("&t=") + 3);
                }
                else
                {
                    timecode = youtubeCode.Substring(youtubeCode.IndexOf("?t=") + 3);
                }
                //and everything before the first seperator
                timecode = timecode.Substring(0, findFirstSeperator(timecode));
                //Ex: t=1m5s&index=2&list=WL&index=3 -> 1m5s
                if (!timecode.Contains("m") && !timecode.Contains("s"))
                {//timecode is just listed as an interger of seconds
                    try
                    {
                        startTimeMillis += Int32.Parse(Regex.Match(timecode, @"\d+").Value) * 1000;
                    }
                    catch (Exception)
                    {
                        //TODO Bad URl found here too
                    }
                }

                if (timecode.Contains("m"))
                {//m in url d
                    String[] parts = timecode.Split("m");
                    startTimeMillis = Int32.Parse(Regex.Match(timecode, @"\d+").Value) * 60000;//Convert the url minutes time to milliseconds
                    if (parts.Length > 1)
                    {
                        timecode = parts[1];
                    }
                }

                if (timecode.Contains("s"))
                {
                    try
                    {
                        startTimeMillis += Int32.Parse(Regex.Match(timecode, @"\d+").Value) * 1000;
                    }
                    catch (Exception)
                    {
                        //TODO badURL found here too
                    }
                }
            }

            return new YoutubeData(videoCode, startTimeMillis);
        }


        //Finds the index of the first location of a seperator character in the URL
        //Returns the end of the string if none are found
        private static int findFirstSeperator(String s)
        {
            int endOfVideoCode = s.Length;
            if (s.Contains("&"))
            {
                endOfVideoCode = Math.Min(endOfVideoCode, s.IndexOf("&"));
            }
            if (s.Contains("?"))
            {
                endOfVideoCode = Math.Min(endOfVideoCode, s.IndexOf("?"));
            }
            if (s.Contains("\n"))
            {
                endOfVideoCode = Math.Min(endOfVideoCode, s.IndexOf("\n"));
            }
            //Code is after url and before the first seperator character (?/&)
            return endOfVideoCode;
        }
    }
}