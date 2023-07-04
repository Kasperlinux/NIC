using NIC.Data;
using NIC.Models.ViewModel;
using NIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NIC.Controllers
{
    public class BlockController : Controller
    {
        public BlockController(DhsMagacoursesContext context)
        {
            this.context=context;
        }

        public DhsMagacoursesContext context { get; }

        [HttpGet]
        public IActionResult AddBlock()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBlock(BlockViewModel addBlock)
        {
            var block = new MBlock()
            {
                StateCode=addBlock.StateCode,
                DistrictCode=addBlock.DistrictCode,
                BlockCode=addBlock.BlockCode,
                BlockName=addBlock.BlockName,
            };
            await context.MBlocks.AddAsync(block);
            await context.SaveChangesAsync();
            return RedirectToAction("EditBlock");
        }
        [HttpGet]
        public async Task<IActionResult> EditBlock()
        {
            var block = await context.MBlocks.ToListAsync();
            return View(block);
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var blockData = await context.MBlocks.FirstOrDefaultAsync(x => x.BlockCode==id);

            if (blockData!=null)
            {
                var viewModel = new BlockViewModel()
                {
                    StateCode=blockData.StateCode,
                    DistrictCode=blockData.DistrictCode,
                    BlockCode=blockData.BlockCode,
                    BlockName=blockData.BlockName,
                };
                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("EditBlock");
        }

        [HttpPost]
        public async Task<IActionResult> View(BlockViewModel model)
        {
            var block = await context.MBlocks.FindAsync(model.BlockCode);
            if (block!=null)
            {
                block.StateCode=model.StateCode;
                block.DistrictCode=model.DistrictCode;
                block.BlockCode=model.BlockCode;
                block.BlockName=model.BlockName;
                await context.SaveChangesAsync();
                return RedirectToAction("EditBlock");
            }
            return View("EditBlock");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BlockViewModel model)
        {
            var block = await context.MBlocks.FindAsync(model.BlockCode);
            if (block!=null)
            {
                context.MBlocks.Remove(block);
                await context.SaveChangesAsync();
                return RedirectToAction("EditBlock");
            }
            return RedirectToAction("EditBlock");
        }

    }
}
