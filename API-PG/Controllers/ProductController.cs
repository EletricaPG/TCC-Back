using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;


namespace API_PG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class ProductController : ControllerBase
    {

        public IBaseService<Product> Service { get; }
        public IMapper Mapper { get; }


        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment hostingEnvironment; 

        public ProductController(IBaseService<Product> service, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostingEnvironment )
        {
            this.hostingEnvironment = hostingEnvironment;
            this.httpContextAccessor =  httpContextAccessor;
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entity = await this.Service.GetAll();
            var results = this.Mapper.Map<Product[]>(entity);
            return Ok(results);
        }

        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetById(string ProductId)
        {
            var entity = await this.Service.GetById(ProductId);
            var results = this.Mapper.Map<Product>(entity);
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductModel product)
        {

            var Prod = this.Mapper.Map<Product>(product);
             Prod.UrlArquivo = "assets/"+ Path.GetFileName(product.UrlArquivo);
             
            this.Service.Add(Prod);
            
        

            if (await this.Service.SaveChangesAsync())
                return Created($"api/Product/{product.Id}", product);
            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var entity = await this.Service.GetById(Id);

            if (entity == null) return NotFound();
            this.Service.Delete(entity);

            if (await this.Service.SaveChangesAsync())
                return Ok();
            return BadRequest();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(string Id, ProductModel model)
        {
            var entity = await this.Service.GetById(Id);

            if (entity == null) return NotFound();
             model.UrlArquivo = "assets/" + Path.GetFileName(model.UrlArquivo);
            this.Mapper.Map(model, entity);
            this.Service.Update(entity);

            if (await this.Service.SaveChangesAsync())

                return Created($"api/Product/{model.Id}", this.Mapper.Map<ProductModel>(entity));
            return BadRequest();
        }




        // [HttpPost("EnviarArquivo")]

        // public IActionResult EnviarArquivo()
        // {
        //     try
        //     {

        //         var formFile = this.httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"] ;
        //         var nomeArquivo = formFile.FileName;
        //         var extensao = nomeArquivo.Split(".").Last();
        //         string novoNomeArquivo = GerarNovoNomeArquivo(nomeArquivo, extensao);
        //         var pastaArquivos = this.hostingEnvironment.WebRootPath + "\\arquivos\\";
        //         var nomeCompleto = pastaArquivos + novoNomeArquivo;

        //         using (var streamArquivos = new FileStream(nomeCompleto, FileMode.Create))
        //         {
        //             formFile.CopyTo(streamArquivos);
        //         }
                
        //         return Ok(novoNomeArquivo);
        //         // Json(novoNomeArquivo)
        //     }

        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.ToString());
        //     }
        // }

        private static string GerarNovoNomeArquivo(string nomeArquivo, string extensao)
        {
            var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
            var novoNomeArquivo = new string(arrayNomeCompacto).Replace("", "-");
            novoNomeArquivo = $"{novoNomeArquivo}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}. {extensao}";
            return novoNomeArquivo;
        }
    }
}