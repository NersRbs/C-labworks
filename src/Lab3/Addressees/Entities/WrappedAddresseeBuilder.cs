using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Loggers.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees.Entities;

public class WrappedAddresseeBuilder
{
    private IAddressee? _addressee;
    private ILogger? _logger;
    private ImportanceLevel? _proxyFilterLevel;

    public WrappedAddresseeBuilder SetAddressees(IAddressee addressee)
    {
        _addressee = addressee;
        return this;
    }

    public WrappedAddresseeBuilder AddLog(ILogger logger)
    {
        _logger = logger;
        return this;
    }

    public WrappedAddresseeBuilder AddFilter(ImportanceLevel proxyFilterLevel)
    {
        _proxyFilterLevel = proxyFilterLevel;
        return this;
    }

    public IAddressee Build()
    {
        if (_addressee is null)
        {
            throw new ArgumentNullException("Addressee is not set");
        }

        if (_logger is not null)
        {
            _addressee = new LogDecorator(_addressee, _logger);
        }

        if (_proxyFilterLevel is not null)
        {
            _addressee = new ProxyFilter(_addressee, _proxyFilterLevel);
        }

        return _addressee;
    }
}