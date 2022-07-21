﻿using BudgetManager.Model;
using MediatR;

namespace BudgetManager.CQRS.Commands.CategoryCommands
{
    public record AddCategoryCommand(Category category) : IRequest;
}
